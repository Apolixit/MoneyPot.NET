//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyPot_RestClient.Test.Generated
{
   using System;
   using NUnit.Framework;
   using System.Threading.Tasks;
   using System.Net.Http;
   using MoneyPot_RestClient.Mockup.Generated.Clients;
   using MoneyPot_RestClient.Generated.Clients;
   using Substrate.NetApi.Model.Types.Primitive;
   using MoneyPot_NetApiExt.Generated.Model.pallet_balances;
   using MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec;
   using MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec;
   
   public class BalancesControllerClientTest : ClientTestBase
   {
      private System.Net.Http.HttpClient _httpClient;
      [SetUp()]
      public void Setup()
      {
         _httpClient = CreateHttpClient();
      }
      [Test()]
      public async System.Threading.Tasks.Task TestTotalIssuance()
      {
         // Construct new Mockup client to test with.
         BalancesControllerMockupClient mockupClient = new BalancesControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         BalancesControllerClient rpcClient = new BalancesControllerClient(_httpClient, subscriptionClient);
         Substrate.NetApi.Model.Types.Primitive.U128 mockupValue = this.GetTestValueU128();


         Assert.IsTrue(await rpcClient.SubscribeTotalIssuance());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetTotalIssuance(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Substrate.NetApi.Model.Types.Primitive.U128 rpcResult = await rpcClient.GetTotalIssuance();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_balances.AccountData GetTestValue3()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.AccountData result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_balances.AccountData();
         result.Free = this.GetTestValueU128();
         result.Reserved = this.GetTestValueU128();
         result.MiscFrozen = this.GetTestValueU128();
         result.FeeFrozen = this.GetTestValueU128();
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 GetTestValue4()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
         result.Value = new MoneyPot_NetApiExt.Generated.Types.Base.Arr32U8();
         result.Value.Create(new Substrate.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8()});
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestAccount()
      {
         // Construct new Mockup client to test with.
         BalancesControllerMockupClient mockupClient = new BalancesControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         BalancesControllerClient rpcClient = new BalancesControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.AccountData mockupValue = this.GetTestValue3();
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 mockupKey = this.GetTestValue4();

         Assert.IsTrue(await rpcClient.SubscribeAccount(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetAccount(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.pallet_balances.AccountData rpcResult = await rpcClient.GetAccount(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT2 GetTestValue6()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT2 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT2();
         result.Value = new Substrate.NetApi.Model.Types.Base.BaseVec<MoneyPot_NetApiExt.Generated.Model.pallet_balances.BalanceLock>();
         result.Value.Create(new MoneyPot_NetApiExt.Generated.Model.pallet_balances.BalanceLock[] {
                  this.GetTestValue7()});
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_balances.BalanceLock GetTestValue7()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.BalanceLock result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_balances.BalanceLock();
         result.Id = new MoneyPot_NetApiExt.Generated.Types.Base.Arr8U8();
         result.Id.Create(new Substrate.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8()});
         result.Amount = this.GetTestValueU128();
         result.Reasons = new MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReasons();
         result.Reasons.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.pallet_balances.Reasons>());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 GetTestValue8()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
         result.Value = new MoneyPot_NetApiExt.Generated.Types.Base.Arr32U8();
         result.Value.Create(new Substrate.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8()});
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestLocks()
      {
         // Construct new Mockup client to test with.
         BalancesControllerMockupClient mockupClient = new BalancesControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         BalancesControllerClient rpcClient = new BalancesControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT2 mockupValue = this.GetTestValue6();
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 mockupKey = this.GetTestValue8();

         Assert.IsTrue(await rpcClient.SubscribeLocks(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetLocks(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT2 rpcResult = await rpcClient.GetLocks(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 GetTestValue10()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3();
         result.Value = new Substrate.NetApi.Model.Types.Base.BaseVec<MoneyPot_NetApiExt.Generated.Model.pallet_balances.ReserveData>();
         result.Value.Create(new MoneyPot_NetApiExt.Generated.Model.pallet_balances.ReserveData[] {
                  this.GetTestValue11()});
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_balances.ReserveData GetTestValue11()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.ReserveData result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_balances.ReserveData();
         result.Id = new MoneyPot_NetApiExt.Generated.Types.Base.Arr8U8();
         result.Id.Create(new Substrate.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8()});
         result.Amount = this.GetTestValueU128();
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 GetTestValue12()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
         result.Value = new MoneyPot_NetApiExt.Generated.Types.Base.Arr32U8();
         result.Value.Create(new Substrate.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8(),
                  this.GetTestValueU8()});
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestReserves()
      {
         // Construct new Mockup client to test with.
         BalancesControllerMockupClient mockupClient = new BalancesControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         BalancesControllerClient rpcClient = new BalancesControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 mockupValue = this.GetTestValue10();
         MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 mockupKey = this.GetTestValue12();

         Assert.IsTrue(await rpcClient.SubscribeReserves(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetReserves(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 rpcResult = await rpcClient.GetReserves(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReleases GetTestValue14()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReleases result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReleases();
         result.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.pallet_balances.Releases>());
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestStorageVersion()
      {
         // Construct new Mockup client to test with.
         BalancesControllerMockupClient mockupClient = new BalancesControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         BalancesControllerClient rpcClient = new BalancesControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReleases mockupValue = this.GetTestValue14();


         Assert.IsTrue(await rpcClient.SubscribeStorageVersion());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetStorageVersion(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.pallet_balances.EnumReleases rpcResult = await rpcClient.GetStorageVersion();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
   }
}
