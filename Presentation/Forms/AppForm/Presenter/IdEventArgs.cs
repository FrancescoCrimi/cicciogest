using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public delegate void IdEventHandler(object sender, IdEventArgs e);

    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(int id) => Id = id;
        public IdEventArgs() => Id = 0;
        public int Id { get; }
    }
}