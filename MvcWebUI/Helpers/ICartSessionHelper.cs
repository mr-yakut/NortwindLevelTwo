﻿

using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ICartSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(string key, Cart cart);
        void Clear();
    }
}
