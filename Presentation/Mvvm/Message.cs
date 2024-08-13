// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public class IdArticoloRequestMessage : AsyncRequestMessage<int> { }
    public class IdArticoloMessage : ValueChangedMessage<int>
    {
        public IdArticoloMessage(int value) : base(value) { }
    }


    public class IdCategoriaRequestMessage : AsyncRequestMessage<int> { }
    public class IdCategoriaMessage : ValueChangedMessage<int>
    {
        public IdCategoriaMessage(int value) : base(value) { }
    }


    public class IdClienteRequestMessage : AsyncRequestMessage<int> { }
    public class IdClienteMessage : ValueChangedMessage<int>
    {
        public IdClienteMessage(int value) : base(value) { }
    }


    public class IdFatturaRequestMessage : AsyncRequestMessage<int> { }
    public class IdFatturaMessage : ValueChangedMessage<int>
    {
        public IdFatturaMessage(int value) : base(value) { }
    }


    public class IdFornitoreRequestMessage : AsyncRequestMessage<int> { }
    public class IdFornitoreMessage : ValueChangedMessage<int>
    {
        public IdFornitoreMessage(int value) : base(value) { }
    }
}
