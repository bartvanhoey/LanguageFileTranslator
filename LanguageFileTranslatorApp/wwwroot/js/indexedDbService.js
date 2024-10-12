let currentVersion = 1;
let databaseName = "LanguageFileTranslatorDb";

const languageEntriesDbStore = "languageEntries";
const languageEntriesKeyIndex = "languageEntriesKeyIndex";
const languageEntryItemsDbStore = "languageEntryItems";
const languageEntryItemsKeyIndex = "languageEntryItemsKeyIndex";

export function initialize() {
    let openRequest = indexedDB.open(databaseName, currentVersion);
    openRequest.onupgradeneeded = function () {
        console.log("onupgradeneeded")

        let db = openRequest.result;
        const languageEntries = db.createObjectStore(languageEntriesDbStore, {keyPath: "id"});
        languageEntries.createIndex(languageEntriesKeyIndex, ["key"], {unique: false})
        console.log('languageEntriesDbStore created');

        const languageEntryItems = db.createObjectStore(languageEntryItemsDbStore, {keyPath: "id"});
        languageEntryItems.createIndex(languageEntryItemsKeyIndex, ["key"], {unique: false})
        console.log('languageEntryItemsDbStore created');
    }
}

function createObjectStoresIfNotExist(openRequest) {
    const objectStoreNames = openRequest.result.objectStoreNames;
    console.log("objectStoreNames: " + objectStoreNames)
    if (!objectStoreNames.contains(languageEntriesDbStore) || !objectStoreNames.contains(languageEntryItemsDbStore)) {
        const DBDeleteRequest = window.indexedDB.deleteDatabase(databaseName);
        console.log("call to initialize")
        initialize();
        console.log("initialize called")
    }
}

export function set(collectionName, value) {
    let openRequest = indexedDB.open(databaseName, currentVersion);
    openRequest.onsuccess = () => {
        let transaction = openRequest.result.transaction(collectionName, "readwrite");
        let objectStore = transaction.objectStore(collectionName)
        objectStore.put(value);
    }
    openRequest.onerror = (e) => alert(openRequest.result)
}

export function setMany(collectionName, items) {
    console.log("collectionName: " + collectionName);
    console.log(items);
    console.log("currentVersion: " + currentVersion);
    let openRequest = indexedDB.open(databaseName, currentVersion);
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
        let openRequest = indexedDB.open(databaseName, currentVersion);
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






export async function getFirstByKey(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            createObjectStoresIfNotExist(openRequest);
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key > b.key) ? 1 : -1);
                resolve(request.result[0]);
            }
            request.onerror = (e) => alert("getFirstByKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getNextLanguageEntryByKey(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
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
            request.onerror = (e) => alert("getNextLanguageEntryByKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getNextLanguageEntryById(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.id > b.id) ? 1 : -1);
                console.log(languageEntry)
                console.log(request.result)
                if (languageEntry == null) return;
                const index = request.result.map(x => x.id).indexOf(languageEntry.id);
                console.log("index:" + index)
                console.log("maxLength:" + request.result.length)
                if (request.result.length === index + 1) {
                    resolve(request.result[index]);
                } else resolve(request.result[index + 1]);
            }
            request.onerror = (e) => alert("getNextLanguageEntryById event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getPreviousLanguageEntryByKey(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
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
                    const previousIndex = index - 1;
                    resolve(request.result[previousIndex]);
                }
            }
            request.onerror = (e) => alert("getPreviousLanguageEntryByKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getLastLanguageEntryByKey(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key < b.key) ? 1 : -1);
                resolve(request.result[0]);
            }
            request.onerror = (e) => alert("getLastLanguageEntryByKey event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getLastLanguageEntryById(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.openCursor(null, "prev");
            request.onsuccess = (e) => {
                const cursor = e.target.result;
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = (e) => alert("getLastLanguageEntryById event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getPreviousLanguageEntryById(collectionName, languageEntry) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.getAll();
            request.onsuccess = () => {
                request.result.sort((a, b) => (a.key > b.key) ? 1 : -1);
                console.log(languageEntry)
                console.log(request.result)
                if (languageEntry == null) return;
                const index = request.result.map(x => x.id).indexOf(languageEntry.id);
                console.log("index:" + index)
                console.log("maxLength:" + request.result.length)
                if (index === 0 || index === -1) {
                    resolve(request.result[0]);
                } else {
                    const previousIndex = index - 1;
                    resolve(request.result[previousIndex]);
                }
            }
            request.onerror = (e) => alert("getPreviousLanguageEntryById event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getFirstLanguageEntryById(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
        openRequest.onsuccess = function () {
            let transaction = openRequest.result.transaction(collectionName, "readonly");
            let objectStore = transaction.objectStore(collectionName);
            const request = objectStore.openCursor();
            request.onsuccess = (e) => {
                const cursor = e.target.result;
                if (!!cursor === false) return;
                resolve(cursor.value);
            }
            request.onerror = (e) => alert("getFirstLanguageEntryById event: " + e + "request" + openRequest.result);
        }
    });
    return await promise;
}

export async function getAll(collectionName) {
    let promise = new Promise((resolve) => {
        let openRequest = indexedDB.open(databaseName, currentVersion);
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
        let openRequest = indexedDB.open(databaseName, currentVersion);
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

