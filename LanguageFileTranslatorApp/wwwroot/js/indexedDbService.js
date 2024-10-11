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
    openRequest.onsuccess = () => {
        let transaction = openRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        objectStore.put(value);
    }
    openRequest.onerror = (e) => alert(openRequest.result)
}

export function setMany(collectionName, items) {
    let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    openRequest.onsuccess = () => {
        let transaction = openRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        for (let i = 0; i < items.length; i++) {
            objectStore.put(items[i]);
        }
    }
    openRequest.onerror = (e) => alert("setMany event: " + e + "request" + openRequest.result)
}


export async function get(collectionName, id) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            let request = objectStore.get(id);
            request.onsuccess = function (e) {
                resolve(request.result);
            }
            request.onerror = (e) => alert("get event: " + e + "request" + openRequest.result);
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
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = (e) => alert("getFirstId event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getFirstKey(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key > b.key) ? 1 : -1);
                resolve(request.result[0]);
            }
            request.onerror = (e) => alert("getFirstKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getNextKey(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key > b.key) ? 1 : -1);
                console.log(languageEntry)
                console.log(request.result)
                if (languageEntry == null) return;
                const index = request.result.map(x => x.key).indexOf(languageEntry.key);
                console.log("index:" + index)
                console.log("maxLength:" + request.result.length)
                if (request.result.length === index + 1) {
                    resolve(request.result[index]);
                } else resolve(request.result[index + 1]);
            }
            request.onerror = (e) => alert("getNextKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getPreviousKey(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key > b.key) ? 1 : -1);
                console.log(languageEntry)
                console.log(request.result)
                if (languageEntry == null) return;
                const index = request.result.map(x => x.key).indexOf(languageEntry.key);
                console.log("index:" + index)
                console.log("maxLength:" + request.result.length)
                if (index === 0 || index === -1) {
                    resolve(request.result[0]);
                } else {
                    const previousIndex =index - 1;
                    resolve(request.result[previousIndex]);
                }
            }
            request.onerror = (e) => alert("getPreviousKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getLastKey(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key < b.key) ? 1 : -1);
                resolve(request.result[0]);
            }
            request.onerror = (e) => alert("getLastKey event: " + e + "request" + openRequest.result);
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
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = (e) => alert("getLastId event: " + e + "request" + openRequest.result);
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
            request.onsuccess = () => resolve(request.result);
            request.onerror = (e) => alert("getAll event: " + e + "request" + openRequest.result);
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
            request.onsuccess = (e) => resolve(request.result);
            request.onerror = (e) => alert("getAllByKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "LanguageFileTranslatorDb";