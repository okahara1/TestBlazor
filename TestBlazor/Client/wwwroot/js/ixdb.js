// データベースの作成①
var db = new Dexie("diarydb");

// オブジェクトストア（テーブル）の作成②
db.version(1).stores({
    diary: 'selectDay'
});

// 指定日の日記を保存する③
function putDiary(val) {
    db.diary.put(val);
}

// 指定日の日記を取得する④
function getDiary(key) {
    return db.diary.get(key);
}

// 指定範囲のキーを返す⑤
function getKeys(s, e) {
    return db.diary.where("selectDay").between(s, e).keys();
}
