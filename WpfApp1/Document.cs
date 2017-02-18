namespace WpfApp1
{
    using Reactive.Bindings;
    using Reactive.Bindings.Extensions;
    using System;
    using System.Linq;
    using System.Reactive.Linq;

    class Document
    {
        public string UserName { get; private set; }

        public ReactiveProperty<bool?> Favorite { get; private set; } = new ReactiveProperty<bool?>();

        public ReactiveProperty<bool> Enabled { get; private set; } = new ReactiveProperty<bool>(true);

        public ReactiveProperty<bool> IsUserFile { get; private set; } = new ReactiveProperty<bool>();

        public ReactiveProperty<string> Name { get; private set; } = new ReactiveProperty<string>();

        public ReactiveProperty<bool> IsPrivateOpenCommandEnabled { get; private set; } = new ReactiveProperty<bool>(true);

        public ReactiveProperty<bool> IsShareOpenCommandEnabled { get; private set; } = new ReactiveProperty<bool>(true);

        public ReactiveCommand ShareOpenCommand { get; private set; }

        public ReactiveCommand ShareCloseCommand { get; private set; }

        public ReactiveCommand PrivateOpenCommand { get; private set; }

        public ReactiveCommand PrivateCloseCommand { get; private set; }

        public ReactiveCommand AdminOpenCommand { get; private set; } = new ReactiveCommand();

        public ReactiveCommand DeleteUserFileCommand { get; private set; }

        public ReactiveCommand UpdateUserProfileCommand { get; private set; } = new ReactiveCommand();

        public Document()
        {
            AdminOpenCommand.Subscribe(_ =>
            {
                AdminOpen();
            });

            ShareOpenCommand = IsShareOpenCommandEnabled.Select(c => c).ToReactiveCommand();

            ShareOpenCommand.Subscribe(_ =>
            {
                ShareOpen();
            });

            ShareCloseCommand = IsShareOpenCommandEnabled.Inverse().ToReactiveCommand();

            ShareCloseCommand.Subscribe(_ =>
            {
                ShareClose();
            });

            DeleteUserFileCommand = IsUserFile.ToReactiveCommand();

            DeleteUserFileCommand.Subscribe(_ =>
            {
                DeleteUserFile();
            });

            PrivateOpenCommand = IsPrivateOpenCommandEnabled.Select(c => c).ToReactiveCommand();

            PrivateOpenCommand.Subscribe(_ =>
            {
                PrivateOpen();
            });

            PrivateCloseCommand = IsPrivateOpenCommandEnabled.Inverse().ToReactiveCommand();

            PrivateCloseCommand.Subscribe(_ =>
            {
                PrivateClose();
            });

            UpdateUserProfileCommand.Subscribe(_ =>
            {
                UpdateUserProfile();
            });
        }

        public Document(string name, bool isUserFile, string user = null, bool? favorite = null) : this()
        {
            Name.Value = name;
            IsUserFile.Value = isUserFile;
            UserName = user;
            Favorite.Value = favorite;
        }

        private void PrivateOpen()
        {
            //コピーを作って開く
        }

        private void PrivateClose()
        {
            //コピーを閉じる
        }

        private void ShareOpen()
        {
            //共通アカウントで開く
            //
        }
        private void ShareClose()
        {
            //共通アカウントで開いたドキュメントを閉じる
        }
        private void AdminOpen()
        {
            //自分のアカウント権限で開く
        }

        private void DeleteUserFile()
        {
            //自分がアップロードしたファイルを削除する
            Enabled.Value = false;

        }

        private void UpdateUserProfile()
        {
            if (Favorite.Value.HasValue == false) return;

            if (Favorite.Value.Value)
            {
                QlikViewApi.AddFavorite(UserName, Name.Value);
            }
            else
            {
                QlikViewApi.RemoveFavorite(UserName, Name.Value);
            }
        }
    }
}
