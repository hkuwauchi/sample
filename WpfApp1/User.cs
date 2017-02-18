namespace WpfApp1
{
    using Reactive.Bindings;
    using System.Collections.Generic;

    class User
    {
        public ReactiveProperty<string> Name { get; private set; }
        public ReactiveCollection<string> Favorites { get; private set; }

        public User(string name ,List<string> favorites)
        {
            Name = new ReactiveProperty<string>(name);
            Favorites = new ReactiveCollection<string>();
            Favorites.AddRangeOnScheduler(favorites);
        }
    }
}
