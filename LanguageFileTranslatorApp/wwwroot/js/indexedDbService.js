export function initialize() {
    let openDBRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openDBRequest.onupgradeneeded = function () {
        alert("i am here")
        let db = openDBRequest.result;
        // db.createObjectStore("books", {keyPath: "id"});
        const languageEntries = db.createObjectStore("languageEntries", {keyPath: "id"});
        languageEntries.createIndex("languageEntriesKeyIndex",["key"],{unique: false})
        
        // const translations = db.createObjectStore("translations", {keyPath: "id"});
    }
}

export function set(collectionName, value) {
    let openDBRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openDBRequest.onsuccess = function () {
        let transaction = openDBRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        objectStore.put(value);
    }
}

export async function get(collectionName, id) {
    let promise = new Promise((resolve) => {
        let openDBRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openDBRequest.onsuccess = function () {
            let transaction = openDBRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            let request = objectStore.get(id);

            request.onsuccess = function (e) {
                console.log(request.result)
                resolve(request.result);
            }

            request.onerror = function (e) {
                console.log(request.result)
            }
        }
    });

    return await promise;
}

export async function getAll(collectionName, key) {
    let promise = new Promise((resolve) => {
        let openDBRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openDBRequest.onsuccess = function () {
            let transaction = openDBRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            
            var all = objectStore.getAll();
            all.onsuccess = () =>{
                console.log(all.result)
            }
            
            const index = objectStore.index("languageEntriesKeyIndex")
            const request = index.getAll([key])
            request.onsuccess = function (e) {
                console.log(request.result)
                resolve(request.result);
            }

            request.onerror = function (e) {
                console.log('error: ' +  request.result)
            }
        }
    });
    return await promise;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "LanguageFileTranslatorDb";