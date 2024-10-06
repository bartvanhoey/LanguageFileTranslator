﻿namespace LanguageFileTranslatorApp.Models.Cultures;

public static class InfoCultures
{
    public static List<InfoCulture> GetInfoCultures()
    {
        var infoCultures = new List<InfoCulture>
        {
            new("Invariant Language", "Invariant Language", "iv", "ivl", "Invariant Language", ""),
            new("Afrikaans", "Afrikaans", "af", "afr", "Afrikaans", "af"),
            new("Afrikaans", "Afrikaans", "af", "afr", "Afrikaans", "af-ZA"),
            new("Amharic", "Amharisch", "am", "amh", "አማርኛ", "am"),
            new("Amharic", "Amharisch", "am", "amh", "አማርኛ", "am-ET"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-AE"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-BH"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-DZ"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-EG"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-IQ"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-JO"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-KW"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-LB"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-LY"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-MA"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-OM"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-QA"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-SA"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-SY"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-TN"),
            new("Arabic", "Arabisch", "ar", "ara", "العربية", "ar-YE"),
            new("Mapuche", "Mapudungun", "arn", "arn", "Mapudungun", "arn"),
            new("Mapuche", "Mapudungun", "arn", "arn", "Mapuche", "arn-CL"),
            new("Assamese", "Assamesisch", "as", "asm", "অসমীয়া", "as"),
            new("Assamese", "Assamesisch", "as", "asm", "অসমীয়া", "as-IN"),
            new("Azerbaijani", "Aserbaidschanisch", "az", "aze", "azərbaycan", "az"),
            new("Azerbaijani", "Aserbaidschanisch", "az", "aze", "азәрбајҹан", "az-Cyrl"),
            new("Azerbaijani", "Aserbaidschanisch", "az", "aze", "азәрбајҹан", "az-Cyrl-AZ"),
            new("Azerbaijani", "Aserbaidschanisch", "az", "aze", "azərbaycan", "az-Latn"),
            new("Azerbaijani", "Aserbaidschanisch", "az", "aze", "azərbaycan", "az-Latn-AZ"),
            new("Bashkir", "Baschkirisch", "ba", "bak", "башҡорт теле", "ba"),
            new("Bashkir", "Baschkirisch", "ba", "bak", "Bashkir", "ba-RU"),
            new("Belarusian", "Belarussisch", "be", "bel", "беларуская", "be"),
            new("Belarusian", "Belarussisch", "be", "bel", "беларуская", "be-BY"),
            new("Bulgarian", "Bulgarisch", "bg", "bul", "български", "bg"),
            new("Bulgarian", "Bulgarisch", "bg", "bul", "български", "bg-BG"),
            new("Edo", "Bini", "bin", "bin", "Ẹ̀dó", "bin"),
            new("Edo", "Bini", "bin", "bin", "Ẹ̀dó", "bin-NG"),
            new("Bangla", "Bengalisch", "bn", "ben", "বাংলা", "bn"),
            new("Bangla", "Bengalisch", "bn", "ben", "বাংলা", "bn-BD"),
            new("Bangla", "Bengalisch", "bn", "ben", "বাংলা", "bn-IN"),
            new("Tibetan", "Tibetisch", "bo", "bod", "བོད་སྐད་", "bo"),
            new("Tibetan", "Tibetisch", "bo", "bod", "བོད་སྐད་", "bo-CN"),
            new("Breton", "Bretonisch", "br", "bre", "brezhoneg", "br"),
            new("Breton", "Bretonisch", "br", "bre", "brezhoneg", "br-FR"),
            new("Bosnian", "Bosnisch", "bs", "bos", "bosanski", "bs"),
            new("Bosnian", "Bosnisch", "bs", "bos", "босански", "bs-Cyrl"),
            new("Bosnian", "Bosnisch", "bs", "bos", "босански", "bs-Cyrl-BA"),
            new("Bosnian", "Bosnisch", "bs", "bos", "bosanski", "bs-Latn"),
            new("Bosnian", "Bosnisch", "bs", "bos", "bosanski", "bs-Latn-BA"),
            new("Catalan", "Katalanisch", "ca", "cat", "català", "ca"),
            new("Catalan", "Katalanisch", "ca", "cat", "català", "ca-ES"),
            new("Cherokee", "Cherokee", "chr", "chr", "ᏣᎳᎩ", "chr"),
            new("Corsican", "Korsisch", "co", "cos", "corsu", "co"),
            new("Corsican", "Korsisch", "co", "cos", "Corsican", "co-FR"),
            new("Czech", "Tschechisch", "cs", "ces", "čeština", "cs"),
            new("Czech", "Tschechisch", "cs", "ces", "čeština", "cs-CZ"),
            new("Welsh", "Walisisch", "cy", "cym", "Cymraeg", "cy"),
            new("Welsh", "Walisisch", "cy", "cym", "Cymraeg", "cy-GB"),
            new("Danish", "Dänisch", "da", "dan", "dansk", "da"),
            new("Danish", "Dänisch", "da", "dan", "dansk", "da-DK"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de-AT"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de-CH"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de-DE"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de-LI"),
            new("German", "Deutsch", "de", "deu", "Deutsch", "de-LU"),
            new("Lower Sorbian", "Niedersorbisch", "dsb", "dsb", "dolnoserbšćina", "dsb"),
            new("Lower Sorbian", "Niedersorbisch", "dsb", "dsb", "dolnoserbšćina", "dsb-DE"),
            new("Divehi", "Dhivehi", "dv", "div", "Divehi", "dv"),
            new("Divehi", "Dhivehi", "dv", "div", "Divehi", "dv-MV"),
            new("Dzongkha", "Dzongkha", "dz", "dzo", "རྫོང་ཁ།", "dz-BT"),
            new("Greek", "Griechisch", "el", "ell", "Ελληνικά", "el"),
            new("Greek", "Griechisch", "el", "ell", "Ελληνικά", "el-GR"),
            new("English", "Englisch", "en", "eng", "English", "en"),
            new("English", "Englisch", "en", "eng", "English", "en-029"),
            new("English", "Englisch", "en", "eng", "English", "en-AU"),
            new("English", "Englisch", "en", "eng", "English", "en-BZ"),
            new("English", "Englisch", "en", "eng", "English", "en-CA"),
            new("English", "Englisch", "en", "eng", "English", "en-GB"),
            new("English", "Englisch", "en", "eng", "English", "en-HK"),
            new("English", "Englisch", "en", "eng", "English", "en-ID"),
            new("English", "Englisch", "en", "eng", "English", "en-IE"),
            new("English", "Englisch", "en", "eng", "English", "en-IN"),
            new("English", "Englisch", "en", "eng", "English", "en-JM"),
            new("English", "Englisch", "en", "eng", "English", "en-MY"),
            new("English", "Englisch", "en", "eng", "English", "en-NZ"),
            new("English", "Englisch", "en", "eng", "English", "en-PH"),
            new("English", "Englisch", "en", "eng", "English", "en-SG"),
            new("English", "Englisch", "en", "eng", "English", "en-TT"),
            new("English", "Englisch", "en", "eng", "English", "en-US"),
            new("English", "Englisch", "en", "eng", "English", "en-ZA"),
            new("English", "Englisch", "en", "eng", "English", "en-ZW"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-419"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-AR"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-BO"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-CL"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-CO"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-CR"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-CU"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-DO"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-EC"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-ES"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-GT"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-HN"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-MX"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-NI"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-PA"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-PE"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-PR"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-PY"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-SV"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-US"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-UY"),
            new("Spanish", "Spanisch", "es", "spa", "español", "es-VE"),
            new("Estonian", "Estnisch", "et", "est", "eesti", "et"),
            new("Estonian", "Estnisch", "et", "est", "eesti", "et-EE"),
            new("Basque", "Baskisch", "eu", "eus", "euskara", "eu"),
            new("Basque", "Baskisch", "eu", "eus", "euskara", "eu-ES"),
            new("Persian", "Persisch", "fa", "fas", "فارسی", "fa"),
            new("Persian", "Persisch", "fa", "fas", "فارسی", "fa-IR"),
            new("Fulah", "Ful", "ff", "ful", "Pulaar", "ff"),
            new("Fulah", "Ful", "ff", "ful", "Fulah", "ff-Latn"),
            new("Fulah", "Ful", "ff", "ful", "Fulah", "ff-Latn-SN"),
            new("Finnish", "Finnisch", "fi", "fin", "suomi", "fi"),
            new("Finnish", "Finnisch", "fi", "fin", "suomi", "fi-FI"),
            new("Filipino", "Filipino", "fil", "fil", "Filipino", "fil"),
            new("Filipino", "Filipino", "fil", "fil", "Filipino", "fil-PH"),
            new("Faroese", "Färöisch", "fo", "fao", "føroyskt", "fo"),
            new("Faroese", "Färöisch", "fo", "fao", "føroyskt", "fo-FO"),
            new("French", "Französisch", "fr", "fra", "français", "fr"),
            new("French", "Französisch", "fr", "fra", "français", "fr-029"),
            new("French", "Französisch", "fr", "fra", "français", "fr-BE"),
            new("French", "Französisch", "fr", "fra", "français", "fr-CA"),
            new("French", "Französisch", "fr", "fra", "français", "fr-CD"),
            new("French", "Französisch", "fr", "fra", "français", "fr-CH"),
            new("French", "Französisch", "fr", "fra", "français", "fr-CI"),
            new("French", "Französisch", "fr", "fra", "français", "fr-CM"),
            new("French", "Französisch", "fr", "fra", "français", "fr-FR"),
            new("French", "Französisch", "fr", "fra", "français", "fr-HT"),
            new("French", "Französisch", "fr", "fra", "français", "fr-LU"),
            new("French", "Französisch", "fr", "fra", "français", "fr-MA"),
            new("French", "Französisch", "fr", "fra", "français", "fr-MC"),
            new("French", "Französisch", "fr", "fra", "français", "fr-ML"),
            new("French", "Französisch", "fr", "fra", "français", "fr-RE"),
            new("French", "Französisch", "fr", "fra", "français", "fr-SN"),
            new("Western Frisian", "Westfriesisch", "fy", "fry", "Frysk", "fy"),
            new("Western Frisian", "Westfriesisch", "fy", "fry", "Frysk", "fy-NL"),
            new("Irish", "Irisch", "ga", "gle", "Gaeilge", "ga"),
            new("Irish", "Irisch", "ga", "gle", "Gaeilge", "ga-IE"),
            new("Scottish Gaelic", "Gälisch", "gd", "gla", "Gàidhlig", "gd"),
            new("Scottish Gaelic", "Gälisch  (Vereinigtes Königreich)", "gd", "gla", "Gàidhlig", "gd-GB"),
            new("Galician", "Galicisch", "gl", "glg", "galego", "gl"),
            new("Galician", "Galicisch", "gl", "glg", "galego", "gl-ES"),
            new("Guarani", "Guaraní", "gn", "grn", "avañe’ẽ", "gn"),
            new("Guarani", "Guaraní", "gn", "grn", "Guarani", "gn-PY"),
            new("Swiss German", "Schweizerdeutsch", "gsw", "gsw", "Schwiizertüütsch", "gsw"),
            new("Swiss German", "Schweizerdeutsch", "gsw", "gsw", "Elsässisch", "gsw-FR"),
            new("Gujarati", "Gujarati", "gu", "guj", "ગુજરાતી", "gu"),
            new("Gujarati", "Gujarati", "gu", "guj", "ગુજરાતી", "gu-IN"),
            new("Hausa", "Haussa", "ha", "hau", "Hausa", "ha"),
            new("Hawaiian", "Hawaiisch", "haw", "haw", "ʻŌlelo Hawaiʻi", "haw"),
            new("Hawaiian", "Hawaiisch", "haw", "haw", "ʻŌlelo Hawaiʻi", "haw-US"),
            new("Hebrew", "Hebräisch", "he", "heb", "עברית", "he"),
            new("Hebrew", "Hebräisch", "he", "heb", "עברית", "he-IL"),
            new("Hindi", "Hindi", "hi", "hin", "हिन्दी", "hi"),
            new("Hindi", "Hindi", "hi", "hin", "हिन्दी", "hi-IN"),
            new("Croatian", "Kroatisch", "hr", "hrv", "hrvatski", "hr"),
            new("Croatian", "Kroatisch", "hr", "hrv", "hrvatski", "hr-BA"),
            new("Croatian", "Kroatisch", "hr", "hrv", "hrvatski", "hr-HR"),
            new("Upper Sorbian", "Obersorbisch", "hsb", "hsb", "hornjoserbšćina", "hsb"),
            new("Upper Sorbian", "Obersorbisch", "hsb", "hsb", "hornjoserbšćina", "hsb-DE"),
            new("Hungarian", "Ungarisch", "hu", "hun", "magyar", "hu"),
            new("Hungarian", "Ungarisch", "hu", "hun", "magyar", "hu-HU"),
            new("Armenian", "Armenisch", "hy", "hye", "հայերեն", "hy"),
            new("Armenian", "Armenisch", "hy", "hye", "հայերեն", "hy-AM"),
            new("Ibibio", "Ibibio", "ibb", "ibb", "Ibibio-Efik", "ibb"),
            new("Ibibio", "Ibibio", "ibb", "ibb", "Ibibio-Efik", "ibb-NG"),
            new("Indonesian", "Indonesisch", "id", "ind", "Indonesia", "id"),
            new("Indonesian", "Indonesisch", "id", "ind", "Indonesia", "id-ID"),
            new("Igbo", "Igbo", "ig", "ibo", "Igbo", "ig"),
            new("Igbo", "Igbo", "ig", "ibo", "Igbo", "ig-NG"),
            new("Yi", "Yi", "ii", "iii", "ꆈꌠꉙ", "ii"),
            new("Yi", "Yi", "ii", "iii", "ꆈꌠꉙ", "ii-CN"),
            new("Icelandic", "Isländisch", "is", "isl", "íslenska", "is"),
            new("Icelandic", "Isländisch", "is", "isl", "íslenska", "is-IS"),
            new("Italian", "Italienisch", "it", "ita", "italiano", "it"),
            new("Italian", "Italienisch", "it", "ita", "italiano", "it-CH"),
            new("Italian", "Italienisch", "it", "ita", "italiano", "it-IT"),
            new("Inuktitut", "Inuktitut", "iu", "iku", "Inuktitut", "iu"),
            new("Inuktitut", "Inuktitut", "iu", "iku", "Inuktitut", "iu-Latn"),
            new("Inuktitut", "Inuktitut", "iu", "iku", "Inuktitut", "iu-Latn-CA"),
            new("Japanese", "Japanisch", "ja", "jpn", "日本語", "ja"),
            new("Japanese", "Japanisch", "ja", "jpn", "日本語", "ja-JP"),
            new("Georgian", "Georgisch", "ka", "kat", "ქართული", "ka"),
            new("Georgian", "Georgisch", "ka", "kat", "ქართული", "ka-GE"),
            new("Kazakh", "Kasachisch", "kk", "kaz", "қазақ тілі", "kk"),
            new("Kazakh", "Kasachisch", "kk", "kaz", "қазақ тілі", "kk-KZ"),
            new("Kalaallisut", "Grönländisch", "kl", "kal", "kalaallisut", "kl"),
            new("Kalaallisut", "Grönländisch", "kl", "kal", "kalaallisut", "kl-GL"),
            new("Khmer", "Khmer", "km", "khm", "ខ្មែរ", "km"),
            new("Khmer", "Khmer", "km", "khm", "ខ្មែរ", "km-KH"),
            new("Kannada", "Kannada", "kn", "kan", "ಕನ್ನಡ", "kn"),
            new("Kannada", "Kannada", "kn", "kan", "ಕನ್ನಡ", "kn-IN"),
            new("Korean", "Koreanisch", "ko", "kor", "한국어", "ko"),
            new("Korean", "Koreanisch", "ko", "kor", "한국어", "ko-KR"),
            new("Konkani", "Konkani", "kok", "kok", "कोंकणी", "kok"),
            new("Konkani", "Konkani", "kok", "kok", "कोंकणी", "kok-IN"),
            new("Kanuri", "Kanuri", "kr", "kau", "Kanuri", "kr"),
            new("Kashmiri", "Kaschmiri", "ks", "kas", "کٲشُر", "ks"),
            new("Kashmiri", "Kaschmiri", "ks", "kas", "کٲشُر", "ks-Arab"),
            new("Kashmiri", "Kaschmiri", "ks", "kas", "Kashmiri", "ks-Deva-IN"),
            new("Kyrgyz", "Kirgisisch", "ky", "kir", "кыргызча", "ky"),
            new("Kyrgyz", "Kirgisisch", "ky", "kir", "кыргызча", "ky-KG"),
            new("Latin", "Latein", "la", "lat", "Latin", "la"),
            new("Luxembourgish", "Luxemburgisch", "lb", "ltz", "Lëtzebuergesch", "lb"),
            new("Luxembourgish", "Luxemburgisch", "lb", "ltz", "Lëtzebuergesch", "lb-LU"),
            new("Lao", "Laotisch", "lo", "lao", "ລາວ", "lo"),
            new("Lao", "Laotisch", "lo", "lao", "ລາວ", "lo-LA"),
            new("Lithuanian", "Litauisch", "lt", "lit", "lietuvių", "lt"),
            new("Lithuanian", "Litauisch", "lt", "lit", "lietuvių", "lt-LT"),
            new("Latvian", "Lettisch", "lv", "lav", "latviešu", "lv"),
            new("Latvian", "Lettisch", "lv", "lav", "latviešu", "lv-LV"),
            new("Maori", "Maori", "mi", "mri", "te reo Māori", "mi"),
            new("Maori", "Maori", "mi", "mri", "te reo Māori", "mi-NZ"),
            new("Macedonian", "Mazedonisch", "mk", "mkd", "македонски", "mk"),
            new("Macedonian", "Mazedonisch", "mk", "mkd", "македонски", "mk-MK"),
            new("Malayalam", "Malayalam", "ml", "mal", "മലയാളം", "ml"),
            new("Malayalam", "Malayalam", "ml", "mal", "മലയാളം", "ml-IN"),
            new("Mongolian", "Mongolisch", "mn", "mon", "монгол", "mn"),
            new("Mongolian", "Mongolisch", "mn", "mon", "монгол", "mn-MN"),
            new("Mongolian", "Mongolisch", "mn", "mon", "Mongolian", "mn-Mong"),
            new("Mongolian", "Mongolisch", "mn", "mon", "Mongolian", "mn-Mong-CN"),
            new("Mongolian", "Mongolisch", "mn", "mon", "ᠮᠣᠩᠭᠣᠯ", "mn-Mong-MN"),
            new("Manipuri", "Meithei", "mni", "mni", "মৈতৈলোন্", "mni"),
            new("Mohawk", "Mohawk", "moh", "moh", "Kanienʼkéha", "moh"),
            new("Mohawk", "Mohawk", "moh", "moh", "Mohawk", "moh-CA"),
            new("Marathi", "Marathi", "mr", "mar", "मराठी", "mr"),
            new("Marathi", "Marathi", "mr", "mar", "मराठी", "mr-IN"),
            new("Malay", "Malaiisch", "ms", "msa", "Melayu", "ms"),
            new("Malay", "Malaiisch", "ms", "msa", "Melayu", "ms-BN"),
            new("Malay", "Malaiisch", "ms", "msa", "Melayu", "ms-MY"),
            new("Maltese", "Maltesisch", "mt", "mlt", "Malti", "mt"),
            new("Maltese", "Maltesisch", "mt", "mlt", "Malti", "mt-MT"),
            new("Burmese", "Birmanisch", "my", "mya", "မြန်မာ", "my"),
            new("Burmese", "Birmanisch", "my", "mya", "မြန်မာ", "my-MM"),
            new("Norwegian Bokmål", "Norwegisch", "nb", "nob", "norsk bokmål", "nb"),
            new("Norwegian Bokmål", "Norwegisch  (Norwegen)", "nb", "nob", "norsk bokmål", "nb-NO"),
            new("Nepali", "Nepalesisch", "ne", "nep", "नेपाली", "ne"),
            new("Nepali", "Nepalesisch", "ne", "nep", "नेपाली", "ne-IN"),
            new("Nepali", "Nepalesisch", "ne", "nep", "नेपाली", "ne-NP"),
            new("Dutch", "Niederländisch", "nl", "nld", "Nederlands", "nl"),
            new("Dutch", "Niederländisch", "nl", "nld", "Nederlands", "nl-BE"),
            new("Dutch", "Niederländisch", "nl", "nld", "Nederlands", "nl-NL"),
            new("Norwegian Nynorsk", "Norwegisch", "nn", "nno", "norsk nynorsk", "nn"),
            new("Norwegian Nynorsk", "Norwegisch  (Norwegen)", "nn", "nno", "norsk nynorsk", "nn-NO"),
            new("Sesotho sa Leboa", "Nord-Sotho", "nso", "nso", "Sesotho sa Leboa", "nso"),
            new("Sesotho sa Leboa", "Nord-Sotho", "nso", "nso", "Sesotho sa Leboa", "nso-ZA"),
            new("Occitan", "Okzitanisch", "oc", "oci", "Occitan", "oc"),
            new("Occitan", "Okzitanisch", "oc", "oci", "Occitan", "oc-FR"),
            new("Oromo", "Oromo", "om", "orm", "Oromoo", "om"),
            new("Oromo", "Oromo", "om", "orm", "Oromoo", "om-ET"),
            new("Odia", "Oriya", "or", "ori", "ଓଡ଼ିଆ", "or"),
            new("Odia", "Oriya", "or", "ori", "ଓଡ଼ିଆ", "or-IN"),
            new("Punjabi", "Punjabi", "pa", "pan", "ਪੰਜਾਬੀ", "pa"),
            new("Punjabi", "Punjabi", "pa", "pan", "پنجابی", "pa-Arab"),
            new("Punjabi", "Punjabi", "pa", "pan", "پنجابی", "pa-Arab-PK"),
            new("Papiamento", "Papiamento", "pap", "pap", "Papiamentu", "pap"),
            new("Papiamento", "Papiamento", "pap", "pap", "Papiamentu", "pap-029"),
            new("Polish", "Polnisch", "pl", "pol", "polski", "pl"),
            new("Polish", "Polnisch", "pl", "pol", "polski", "pl-PL"),
            new("Pashto", "Paschtu", "ps", "pus", "پښتو", "ps"),
            new("Pashto", "Paschtu", "ps", "pus", "پښتو", "ps-AF"),
            new("Portuguese", "Portugiesisch", "pt", "por", "português", "pt"),
            new("Portuguese", "Portugiesisch", "pt", "por", "português", "pt-BR"),
            new("Portuguese", "Portugiesisch", "pt", "por", "português", "pt-PT"),
            new("Kʼicheʼ", "K’iche’", "quc", "quc", "Kʼicheʼ", "quc"),
            new("Romansh", "Rätoromanisch", "rm", "roh", "rumantsch", "rm"),
            new("Romansh", "Rätoromanisch", "rm", "roh", "rumantsch", "rm-CH"),
            new("Romanian", "Rumänisch", "ro", "ron", "română", "ro"),
            new("Romanian", "Rumänisch", "ro", "ron", "română", "ro-MD"),
            new("Romanian", "Rumänisch", "ro", "ron", "română", "ro-RO"),
            new("Russian", "Russisch", "ru", "rus", "русский", "ru"),
            new("Russian", "Russisch", "ru", "rus", "русский", "ru-MD"),
            new("Russian", "Russisch", "ru", "rus", "русский", "ru-RU"),
            new("Kinyarwanda", "Kinyarwanda", "rw", "kin", "Kinyarwanda", "rw"),
            new("Kinyarwanda", "Kinyarwanda", "rw", "kin", "Kinyarwanda", "rw-RW"),
            new("Sanskrit", "Sanskrit", "sa", "san", "संस्कृत भाषा", "sa"),
            new("Sanskrit", "Sanskrit", "sa", "san", "संस्कृत भाषा", "sa-IN"),
            new("Sakha", "Jakutisch", "sah", "sah", "саха тыла", "sah"),
            new("Sakha", "Jakutisch", "sah", "sah", "саха тыла", "sah-RU"),
            new("Sindhi", "Sindhi", "sd", "snd", "سنڌي", "sd"),
            new("Sindhi", "Sindhi", "sd", "snd", "سنڌي", "sd-Arab"),
            new("Sindhi", "Sindhi", "sd", "snd", "سنڌي", "sd-Arab-PK"),
            new("Sindhi", "Sindhi", "sd", "snd", "सिन्धी", "sd-Deva-IN"),
            new("Northern Sami", "Nordsamisch", "se", "sme", "davvisámegiella", "se"),
            new("Northern Sami", "Nordsamisch", "se", "sme", "davvisámegiella", "se-FI"),
            new("Northern Sami", "Nordsamisch", "se", "sme", "davvisámegiella", "se-NO"),
            new("Northern Sami", "Nordsamisch", "se", "sme", "davvisámegiella", "se-SE"),
            new("Sinhala", "Singhalesisch", "si", "sin", "සිංහල", "si"),
            new("Sinhala", "Singhalesisch", "si", "sin", "සිංහල", "si-LK"),
            new("Slovak", "Slowakisch", "sk", "slk", "slovenčina", "sk"),
            new("Slovak", "Slowakisch", "sk", "slk", "slovenčina", "sk-SK"),
            new("Slovenian", "Slowenisch", "sl", "slv", "slovenščina", "sl"),
            new("Slovenian", "Slowenisch", "sl", "slv", "slovenščina", "sl-SI"),
            new("Southern Sami", "Südsamisch", "sma", "sma", "Åarjelsaemien gïele", "sma"),
            new("Southern Sami", "Südsamisch", "sma", "sma", "Southern Sami", "sma-NO"),
            new("Southern Sami", "Südsamisch", "sma", "sma", "Southern Sami", "sma-SE"),
            new("Lule Sami", "Lule-Samisch", "smj", "smj", "julevsámegiella", "smj"),
            new("Lule Sami", "Lule-Samisch", "smj", "smj", "Lule Sami", "smj-NO"),
            new("Lule Sami", "Lule-Samisch", "smj", "smj", "Lule Sami", "smj-SE"),
            new("Inari Sami", "Inari-Samisch", "smn", "smn", "anarâškielâ", "smn"),
            new("Inari Sami", "Inari-Samisch", "smn", "smn", "anarâškielâ", "smn-FI"),
            new("Skolt Sami", "Skolt-Samisch", "sms", "sms", "Skolt Sami", "sms"),
            new("Skolt Sami", "Skolt-Samisch", "sms", "sms", "Skolt Sami", "sms-FI"),
            new("Somali", "Somali", "so", "som", "Soomaali", "so"),
            new("Somali", "Somali", "so", "som", "Soomaali", "so-SO"),
            new("Albanian", "Albanisch", "sq", "sqi", "shqip", "sq"),
            new("Albanian", "Albanisch", "sq", "sqi", "shqip", "sq-AL"),
            new("Serbian", "Serbisch", "sr", "srp", "српски", "sr"),
            new("Serbian", "Serbisch", "sr", "srp", "српски", "sr-Cyrl"),
            new("Serbian", "Serbisch", "sr", "srp", "српски", "sr-Cyrl-BA"),
            new("Serbian", "Serbisch", "sr", "srp", "српски", "sr-Cyrl-ME"),
            new("Serbian", "Serbisch", "sr", "srp", "српски", "sr-Cyrl-RS"),
            new("Serbian", "Serbisch", "sr", "srp", "srpski", "sr-Latn"),
            new("Serbian", "Serbisch", "sr", "srp", "srpski", "sr-Latn-BA"),
            new("Serbian", "Serbisch", "sr", "srp", "srpski", "sr-Latn-ME"),
            new("Serbian", "Serbisch", "sr", "srp", "srpski", "sr-Latn-RS"),
            new("Sesotho", "Süd-Sotho", "st", "sot", "Sesotho", "st"),
            new("Sesotho", "Süd-Sotho", "st", "sot", "Sesotho", "st-ZA"),
            new("Swedish", "Schwedisch", "sv", "swe", "svenska", "sv"),
            new("Swedish", "Schwedisch", "sv", "swe", "svenska", "sv-FI"),
            new("Swedish", "Schwedisch", "sv", "swe", "svenska", "sv-SE"),
            new("Kiswahili", "Suaheli", "sw", "swa", "Kiswahili", "sw"),
            new("Kiswahili", "Suaheli", "sw", "swa", "Kiswahili", "sw-KE"),
            new("Syriac", "Syrisch", "syr", "syr", "Syriac", "syr"),
            new("Syriac", "Syrisch", "syr", "syr", "Syriac", "syr-SY"),
            new("Tamil", "Tamil", "ta", "tam", "தமிழ்", "ta"),
            new("Tamil", "Tamil", "ta", "tam", "தமிழ்", "ta-IN"),
            new("Tamil", "Tamil", "ta", "tam", "தமிழ்", "ta-LK"),
            new("Telugu", "Telugu", "te", "tel", "తెలుగు", "te"),
            new("Telugu", "Telugu", "te", "tel", "తెలుగు", "te-IN"),
            new("Tajik", "Tadschikisch", "tg", "tgk", "тоҷикӣ", "tg"),
            new("Thai", "Thailändisch", "th", "tha", "ไทย", "th"),
            new("Thai", "Thailändisch", "th", "tha", "ไทย", "th-TH"),
            new("Tigrinya", "Tigrinya", "ti", "tir", "ትግር", "ti"),
            new("Tigrinya", "Tigrinya", "ti", "tir", "ትግር", "ti-ER"),
            new("Tigrinya", "Tigrinya", "ti", "tir", "ትግር", "ti-ET"),
            new("Turkmen", "Turkmenisch", "tk", "tuk", "türkmen dili", "tk"),
            new("Turkmen", "Turkmenisch", "tk", "tuk", "türkmen dili", "tk-TM"),
            new("Setswana", "Tswana", "tn", "tsn", "Setswana", "tn"),
            new("Setswana", "Tswana", "tn", "tsn", "Setswana", "tn-BW"),
            new("Setswana", "Tswana", "tn", "tsn", "Setswana", "tn-ZA"),
            new("Turkish", "Türkisch", "tr", "tur", "Türkçe", "tr"),
            new("Turkish", "Türkisch", "tr", "tur", "Türkçe", "tr-TR"),
            new("Xitsonga", "Tsonga", "ts", "tso", "Xitsonga", "ts"),
            new("Xitsonga", "Tsonga", "ts", "tso", "Xitsonga", "ts-ZA"),
            new("Tatar", "Tatarisch", "tt", "tat", "татар", "tt"),
            new("Tatar", "Tatarisch", "tt", "tat", "татар", "tt-RU"),
            new("Central Atlas Tamazight", "Zentralatlas-Tamazight", "tzm", "tzm", "Tamaziɣt n laṭlaṣ", "tzm"),
            new("Central Atlas Tamazight", "Zentralatlas-Tamazight", "tzm", "tzm", "Central Atlas Tamazight",
                "tzm-Arab-MA"),
            new("Central Atlas Tamazight", "Zentralatlas-Tamazight", "tzm", "tzm", "Central Atlas Tamazight",
                "tzm-Tfng"),
            new("Central Atlas Tamazight", "Zentralatlas-Tamazight", "tzm", "tzm", "Central Atlas Tamazight",
                "tzm-Tfng-MA"),
            new("Uyghur", "Uigurisch", "ug", "uig", "ئۇيغۇرچە", "ug"),
            new("Uyghur", "Uigurisch", "ug", "uig", "ئۇيغۇرچە", "ug-CN"),
            new("Ukrainian", "Ukrainisch", "uk", "ukr", "українська", "uk"),
            new("Ukrainian", "Ukrainisch", "uk", "ukr", "українська", "uk-UA"),
            new("Urdu", "Urdu", "ur", "urd", "اردو", "ur"),
            new("Urdu", "Urdu", "ur", "urd", "اردو", "ur-IN"),
            new("Urdu", "Urdu", "ur", "urd", "اردو", "ur-PK"),
            new("Uzbek", "Usbekisch", "uz", "uzb", "o‘zbek", "uz"),
            new("Uzbek", "Usbekisch", "uz", "uzb", "ўзбекча", "uz-Cyrl"),
            new("Uzbek", "Usbekisch", "uz", "uzb", "ўзбекча", "uz-Cyrl-UZ"),
            new("Uzbek", "Usbekisch", "uz", "uzb", "o‘zbek", "uz-Latn"),
            new("Uzbek", "Usbekisch", "uz", "uzb", "o‘zbek", "uz-Latn-UZ"),
            new("Venda", "Venda", "ve", "ven", "Venda", "ve"),
            new("Venda", "Venda", "ve", "ven", "Venda", "ve-ZA"),
            new("Vietnamese", "Vietnamesisch", "vi", "vie", "Tiếng Việt", "vi"),
            new("Vietnamese", "Vietnamesisch", "vi", "vie", "Tiếng Việt", "vi-VN"),
            new("Wolof", "Wolof", "wo", "wol", "Wolof", "wo"),
            new("Wolof", "Wolof", "wo", "wol", "Wolof", "wo-SN"),
            new("isiXhosa", "Xhosa", "xh", "xho", "isiXhosa", "xh"),
            new("isiXhosa", "Xhosa", "xh", "xho", "isiXhosa", "xh-ZA"),
            new("Yiddish", "Jiddisch", "yi", "yid", "ייִדיש", "yi"),
            new("Yiddish", "Jiddisch", "yi", "yid", "ייִדיש", "yi-001"),
            new("Yoruba", "Yoruba", "yo", "yor", "Èdè Yorùbá", "yo"),
            new("Yoruba", "Yoruba", "yo", "yor", "Èdè Yorùbá", "yo-NG"),
            new("Chinese", "Chinesisch", "zh", "zho", "中文", "zh"),
            new("Chinese", "Chinesisch", "zh", "zho", "中文（简体）", "zh-Hans"),
            new("Chinese", "Chinesisch", "zh", "zho", "中文（繁體）", "zh-Hant"),
            new("isiZulu", "Zulu", "zu", "zul", "isiZulu", "zu"),
            new("isiZulu", "Zulu", "zu", "zul", "isiZulu", "zu-ZA")
        };

        return infoCultures;
    }
}