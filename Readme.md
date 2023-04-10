# Money pot Blazor Front End

<img src="https://github.com/Apolixit/MoneyPot.NET/blob/master/MoneyPot_BlazorFront/wwwroot/images/money_pot_logo_no_background.png"  width="200" height="279">

This repo is the [money pot pallet front end](https://github.com/Apolixit/pallet_money_pot) developped with [ASP.NET Core Blazor](https://learn.microsoft.com/fr-fr/aspnet/core/blazor/)

It is a Blazor .Net web application that serves as a proof of concept for building a Substrate blockchain front end.
This project demonstrates how a blockchain front-end can be developed without using Javascript. 

I use [Substrate.NET.Toolchain](https://github.com/SubstrateGaming/Substrate.NET.Toolchain) to automatically generate the C# and substrate connection layers based on the current Substrate metadata file.

---

## Schema

![image](https://github.com/Apolixit/MoneyPot.NET/blob/master/MoneyPot_BlazorFront/wwwroot/images/SubstrateMoneyPot.drawio.svg)

## Setup

If you want to try it by yourself, feel free to clone the repo and use `npm update` in the MoneyPot_BlazorFront project.
If you just want to test with mock data make sure in your Program.cs to use the following dependency injection :
```c#
services.AddMoneyPotServices(MoneyPotServiceExtension.ServiceMode.Mock, endpoint);
```
Otherwise if you want to connect it to the Money pot pallet, please use the following dependency injection :
```c#
services.AddMoneyPotServices(MoneyPotServiceExtension.ServiceMode.SubstrateNode, endpoint);
```

## [Screenshot are available here](https://github.com/Apolixit/MoneyPot.NET/tree/master/Screenshot)


---

The project is under development and will probably change in near future
