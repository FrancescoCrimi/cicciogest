// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CiccioGest.Presentation.WinUiBackend
{
    public class FatturaIdMessage : ValueChangedMessage<int>
    {
        public FatturaIdMessage(int value) : base(value) { }
    }

    public class ArticoloIdMessage : ValueChangedMessage<int>
    {
        public ArticoloIdMessage(int value) : base(value) { }
    }

    public class ClienteIdMessage : ValueChangedMessage<int>
    {
        public ClienteIdMessage(int value) : base(value) { }
    }

    public class FornitoreIdMessage : ValueChangedMessage<int>
    {
        public FornitoreIdMessage(int value) : base(value) { }
    }

    public class CategoriaIdMessage : ValueChangedMessage<int>
    {
        public CategoriaIdMessage(int value) : base(value) { }
    }
}
