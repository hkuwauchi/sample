namespace WpfApp1
{
    using Reactive.Bindings;
    using System;
    using System.IO;
    using System.Linq;

    class MainWindowViewModel
    {
        public Documents Documents { get; private set; } = new Documents();

        public ReactiveProperty<int> UserDocumentCount { get; private set; } = new ReactiveProperty<int>();

        public User User { get; private set; }

        public ReactiveCommand UpdateListCommand { get; private set; } = new ReactiveCommand();

        public ReactiveCommand UploadCommand { get; private set; } = new ReactiveCommand();

        public MainWindowViewModel()
        {
            User = LoadUserProfile();

            UpdateList();

            UpdateListCommand.Subscribe(_ =>
            {
                UpdateList();
            });

            UploadCommand.Subscribe(_ =>
            {
                var path = _ as string;
                Upload(path);
            });

        }

        private User LoadUserProfile()
        {
            var userProfile = QlikViewApi.GetUserProfile(Environment.UserName);

            return new User(userProfile.Name, userProfile.Favorites);

        }

        private void UpdateList()
        {
            Documents.Clear();

            Documents.Add(new Document("test", true, User.Name.Value, true));

            UserDocumentCount.Value = Documents.Count(c => c.UserName == User.Name.Value);

            //自分のユーザーファイル
            //共有ファイル
            //他人のユーザーファイル

            //セッションはすべてQuitする
        }

        private void Upload(string path)
        {
            //ここでDocumentsにアップロードファイルを一番上に挿入
            Documents.InsertOnScheduler(0, new Document(Path.GetFileName(path), true, User.Name.Value, false));
        }
    }
}
