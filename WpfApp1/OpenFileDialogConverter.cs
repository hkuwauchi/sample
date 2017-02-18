namespace WpfApp1
{
    using Microsoft.Win32;
    using Reactive.Bindings.Interactivity;
    using System;
    using System.Linq;
    using System.Reactive.Linq;

    public class OpenFileDialogConverter : ReactiveConverter<EventArgs, string>
    {

        protected override IObservable<string> OnConvert(IObservable<EventArgs> source)
        {
            return source
                .Select(_ => new OpenFileDialog())
                .Do(x => { x.Filter = "qvwファイル(*.qvw)|*.qvw"; x.Title = "ファイルを開く"; })
                .Where(x => x.ShowDialog() == true)
                .Select(x => x.FileName);
        }
    }
}
