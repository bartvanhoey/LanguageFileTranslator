export function initialize() {
    let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openRequest.onupgradeneeded = function () {
        let db = openRequest.result;

        const languageEntries = db.createObjectStore("languageEntries", {keyPath: "id"});
        languageEntries.createIndex("languageEntriesKeyIndex", ["key"], {unique: false})

        const languageEntryItems = db.createObjectStore("languageEntryItems", {keyPath: "id"});
        languageEntryItems.createIndex("languageEntryItemsKeyIndex", ["key"], {unique: false})
    }
}

export function set(collectionName, value) {
    let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openRequest.onsuccess =  () => {
        let transaction = openRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        objectStore.put(value);
    }
    openRequest.onerror = (e) => console.log(openRequest.result)
}

export function setMany(collectionName, items) {
    let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openRequest.onsuccess =  () => {
        let transaction = openRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        for (let i = 0; i < items.length; i++) {
            objectStore.put(items[i]);
        }
    }
    openRequest.onerror = (e) => console.log(openRequest.result)

}


export async function get(collectionName, id) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
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


export async function getFirstId(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.openCursor();
            request.onsuccess = (e) => {
                const cursor = e.target.result;
                console.log(cursor)
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = function (e) {
                console.log('error: ' + request.result)
            }
        }
    });
    return await promise;
}

export async function getLastId(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.openCursor(null, "prev");
            request.onsuccess = (e) => {
                const cursor = e.target.result;
                console.log(cursor)
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = function (e) {
                console.log('error: ' + request.result)
            }
        }
    });
    return await promise;
}


export async function getAll(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);

            const request = objectStore.getAll();
            request.onsuccess = () => {
                console.log(request.result)
                resolve(request.result);
            }
            request.onerror = function (e) {
                console.log('error: ' + request.result)
            }
        }
    });
    return await promise;
}


export async function getAllByKey(collectionName, key) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const index = objectStore.index("languageEntriesKeyIndex")
            const request = index.getAll([key])
            request.onsuccess = function (e) {
                console.log(request.result)
                resolve(request.result);
            }
            request.onerror = function (e) {
                console.log('error: ' + request.result)
            }
        }
    });
    return await promise;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "LanguageFileTranslatorDb";