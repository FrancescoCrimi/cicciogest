using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public delegate void IdEventHandler(object sender, IdEventArgs e);

    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}