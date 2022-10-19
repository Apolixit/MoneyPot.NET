# Money pot Blazor Front End

This repo is the [money pot pallet front end](https://github.com/Apolixit/pallet_money_pot) developped with [ASP.NET Core Blazor](https://learn.microsoft.com/fr-fr/aspnet/core/blazor/)

It's a proof of concept to developp a blockchain front end application without Javascript.
I use [Ajuna.SDK](https://github.com/ajuna-network/Ajuna.SDK) which create automatically all the C# and substrate connexion layer based of the current
Substrate metadata file.

---

If you want to try it by yourself, feel free to clone the repo and use `npm update` in the MoneyPot_BlazorFront project.
If you just want to test with mock data make sure in your Program.cs to use the following dependency injection :
```c#
services.AddMoneyPotServices(MoneyPotServiceExtension.ServiceMode.Mock, endpoint);
```
Otherwise if you want to connect it to the Money pot pallet, please use the following dependency injection :
```c#
services.AddMoneyPotServices(MoneyPotServiceExtension.ServiceMode.SubstrateNode, endpoint);    
```

---

The project is under development and will probably change in near future
