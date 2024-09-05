export function initialize()
{
    let jsonTranslatorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    jsonTranslatorIndexedDb.onupgradeneeded = function ()
    {
        let db = jsonTranslatorIndexedDb.result;
        db.createObjectStore("books", { keyPath: "id" });
        const languageEntries = db.createObjectStore("languageEntries", { keyPath: "id" });
        languageEntries.createIndex("json_file_name_db",["jsonfilename"],{unique: false})
    }
}

export function set(collectionName, value)
{
    let jsonTranslatorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

    jsonTranslatorIndexedDb.onsuccess = function ()
    {
        let transaction = jsonTranslatorIndexedDb.result.transaction(collectionName, "readwrite");
        let collection = transaction.objectStore(collectionName)
        collection.put(value);
    }
}

export async function get(collectionName, id)
{
    let request = new Promise((resolve) =>
    {
        let jsonTranslatorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        jsonTranslatorIndexedDb.onsuccess = function ()
        {
            let transaction = jsonTranslatorIndexedDb.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);
            let result = collection.get(id);

            result.onsuccess = function (e)
            {
                resolve(result.result);
            }
        }
    });

    let result = await request;

    return result;
}

export async function getAll(collectionName, jsonFileName)
{
    let request = new Promise((resolve) =>
    {
        let jsonTranslatorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        jsonTranslatorIndexedDb.onsuccess = function ()
        {
            let transaction = jsonTranslatorIndexedDb.result.transaction(collectionName, "readonly");
            let store = transaction.objectStore(collectionName);
            const jsonFileNameIndex = store.index("json_file_name_db") 
            // let result = store.get("json_file_name_db");

            const query = jsonFileNameIndex.getAll([jsonFileName])
            
            query.onsuccess = function (e)
            {
                resolve(query.result);
            }
        }
    });

    let result = await request;

    return result;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "JsonTranslatorDb";