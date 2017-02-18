namespace WpfApp1
{
    using System;
    using System.Collections.Generic;

    class UserProfile
    {
        public string Name { get; set; } = Environment.UserName;
        public List<string> Favorites { get; set; }
    }
}
