﻿namespace ShoppingCart.ShoppingCart
{
  using EventFeed;
  using Nancy;
  using Nancy.ModelBinding;

  public class ShoppingCartModule : NancyModule
  {
    public ShoppingCartModule(
      IShoppingCartStore shoppingCartStore,
      IProductCatalogueClient productCatalogue,
      IEventStore eventStore) 
      : base("/shoppingcart")
    {
      Get("/{userid:int}", parameters =>
      {
        var userId = (int) parameters.userid;
        return shoppingCartStore.Get(userId);
      });

      Post("/{userid:int}/items", async (parameters, _) =>
      {
        var productCatalogueIds = this.Bind<int[]>();
        var userId = (int) parameters.userid;

        var shoppingCart = shoppingCartStore.Get(userId);
        var shoppingCartItems = await productCatalogue.GetShoppingCartItems(productCatalogueIds).ConfigureAwait(false);
        shoppingCart.AddItems(shoppingCartItems, eventStore);
        shoppingCartStore.Save(shoppingCart);

        return shoppingCart;
      });

      Delete("/{userid:int}/items", parameters =>
      {
        var productCatalogueIds = this.Bind<int[]>();
        var userId = (int)parameters.userid;

        var shoppingCart = shoppingCartStore.Get(userId);
        shoppingCart.RemoveItems(productCatalogueIds, eventStore);
        shoppingCartStore.Save(shoppingCart);

        return shoppingCart;
      });
    }
  }
}
