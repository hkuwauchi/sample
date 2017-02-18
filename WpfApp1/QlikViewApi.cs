namespace WpfApp1
{
    using System.Collections.Generic;
    using System.IO;

    class QlikViewApi
    {

        public static List<Qvw> CreateList()
        {
            //qvwから直接リスト作成
            return new List<Qvw>();
        }

        public static Qvw Upload(string path, string userName)
        {
            return new Qvw()
            {
                Name = Path.GetFileName(path),
                UserName = userName,
                IsCopyFile = false,
                IsUserFile = true
            };
        }

        public static UserProfile GetUserProfile(string userName)
        {
            //UserProfileを取得する
            //なかったら作る
            return new UserProfile() { Name = userName, Favorites = new List<string>() };
        }

        public static void UpdateUserProfile(UserProfile userProfile)
        {
            //UserProfileを更新する
        }

        public static void AddFavorite(string userName, string documentName)
        {
            var up = GetUserProfile(userName);
            up.Favorites.Add(documentName);
            UpdateUserProfile(up);
        }

        public static void RemoveFavorite(string userName, string documentName)
        {
            var up = GetUserProfile(userName);
            up.Favorites.Remove(documentName);
            UpdateUserProfile(up);
        }

        public static void DeleteUserFile(string name)
        {
            //ユーザーファイルを削除する
        }

        public static void ShareOpen(string name)
        {
            //共通アカウントで開く
            //セッション共有用
        }

        public static void ShareClose(string name)
        {
            //共通アカウントで開く
            //セッション共有用
        }

        public static void PrivateOpen(string name)
        {
            //Copyしたいファイル名からCopyフォルダにコピーを作成
            //AccessPointからコピーファイルへ移動
            //開いたらすぐ削除してもいいかも？
        }

        public static void PrivateClose(string name)
        {
            //Copyファイルの削除
            //ブラウザの終了
        }
    }
}
