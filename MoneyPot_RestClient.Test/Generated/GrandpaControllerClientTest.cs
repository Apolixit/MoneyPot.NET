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
   using MoneyPot_NetApiExt.Generated.Model.pallet_grandpa;
   using Substrate.NetApi.Model.Types.Primitive;
   using Substrate.NetApi.Model.Types.Base;
   
   public class GrandpaControllerClientTest : ClientTestBase
   {
      private System.Net.Http.HttpClient _httpClient;
      [SetUp()]
      public void Setup()
      {
         _httpClient = CreateHttpClient();
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.EnumStoredState GetTestValue2()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.EnumStoredState result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.EnumStoredState();
         result.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredState>(), this.GetTestValueBaseVoid());
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestState()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.EnumStoredState mockupValue = this.GetTestValue2();


         Assert.IsTrue(await rpcClient.SubscribeState());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetState(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.EnumStoredState rpcResult = await rpcClient.GetState();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredPendingChange GetTestValue4()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredPendingChange result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredPendingChange();
         result.ScheduledAt = this.GetTestValueU32();
         result.Delay = this.GetTestValueU32();
         result.NextAuthorities = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT1();
         result.NextAuthorities = this.GetTestValue5();
         result.Forced = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
         result.Forced.Create(this.GetTestValueU32());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT1 GetTestValue5()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT1 result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT1();
         result.Value = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>();
         result.Value.Create(new Substrate.NetApi.Model.Types.Base.BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>[] {
                  this.GetTestValue6()});
         return result;
      }
      public Substrate.NetApi.Model.Types.Base.BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64> GetTestValue6()
      {
         Substrate.NetApi.Model.Types.Base.BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64> result;
         result = new Substrate.NetApi.Model.Types.Base.BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>();
         result.Create(this.GetTestValue7(), this.GetTestValueU64());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public GetTestValue7()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_finality_grandpa.app.Public();
         result.Value = new MoneyPot_NetApiExt.Generated.Model.sp_core.ed25519.Public();
         result.Value = this.GetTestValue8();
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_core.ed25519.Public GetTestValue8()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_core.ed25519.Public result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_core.ed25519.Public();
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
      public async System.Threading.Tasks.Task TestPendingChange()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredPendingChange mockupValue = this.GetTestValue4();


         Assert.IsTrue(await rpcClient.SubscribePendingChange());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetPendingChange(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.StoredPendingChange rpcResult = await rpcClient.GetPendingChange();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      [Test()]
      public async System.Threading.Tasks.Task TestNextForced()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         Substrate.NetApi.Model.Types.Primitive.U32 mockupValue = this.GetTestValueU32();


         Assert.IsTrue(await rpcClient.SubscribeNextForced());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetNextForced(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Substrate.NetApi.Model.Types.Primitive.U32 rpcResult = await rpcClient.GetNextForced();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> GetTestValue11()
      {
         Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> result;
         result = new Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>();
         result.Create(this.GetTestValueU32(), this.GetTestValueU32());
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestStalled()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> mockupValue = this.GetTestValue11();


         Assert.IsTrue(await rpcClient.SubscribeStalled());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetStalled(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> rpcResult = await rpcClient.GetStalled();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      [Test()]
      public async System.Threading.Tasks.Task TestCurrentSetId()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         Substrate.NetApi.Model.Types.Primitive.U64 mockupValue = this.GetTestValueU64();


         Assert.IsTrue(await rpcClient.SubscribeCurrentSetId());

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetCurrentSetId(mockupValue);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Substrate.NetApi.Model.Types.Primitive.U64 rpcResult = await rpcClient.GetCurrentSetId();

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      [Test()]
      public async System.Threading.Tasks.Task TestSetIdSession()
      {
         // Construct new Mockup client to test with.
         GrandpaControllerMockupClient mockupClient = new GrandpaControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         GrandpaControllerClient rpcClient = new GrandpaControllerClient(_httpClient, subscriptionClient);
         Substrate.NetApi.Model.Types.Primitive.U32 mockupValue = this.GetTestValueU32();
         Substrate.NetApi.Model.Types.Primitive.U64 mockupKey = this.GetTestValueU64();

         Assert.IsTrue(await rpcClient.SubscribeSetIdSession(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetSetIdSession(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Substrate.NetApi.Model.Types.Primitive.U32 rpcResult = await rpcClient.GetSetIdSession(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
   }
}
