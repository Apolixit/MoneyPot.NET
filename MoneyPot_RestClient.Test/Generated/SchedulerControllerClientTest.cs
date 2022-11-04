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
   using Ajuna.NetApi.Model.Types.Base;
   using Ajuna.NetApi.Model.Types.Primitive;
   
   public class SchedulerControllerClientTest : ClientTestBase
   {
      private System.Net.Http.HttpClient _httpClient;
      [SetUp()]
      public void Setup()
      {
         _httpClient = CreateHttpClient();
      }
      public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>> GetTestValue2()
      {
         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>>();
         result.Create(new Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>[] {
                  this.GetTestValue3()});
         return result;
      }
      public Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3> GetTestValue3()
      {
         Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>();
         result.Create(this.GetTestValue4());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3 GetTestValue4()
      {
         MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3 result;
         result = new MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3();
         result.MaybeId = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>();
         result.MaybeId.Create(this.GetTestValue5());
         result.Priority = this.GetTestValueU8();
         result.Call = new MoneyPot_NetApiExt.Generated.Model.frame_support.traits.schedule.EnumMaybeHashed();
         result.Call.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.frame_support.traits.schedule.MaybeHashed>(), this.GetTestValue6());
         result.MaybePeriodic = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>>();
         result.MaybePeriodic.Create(this.GetTestValue9());
         result.Origin = new MoneyPot_NetApiExt.Generated.Model.node_template_runtime.EnumOriginCaller();
         result.Origin.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.node_template_runtime.OriginCaller>(), this.GetTestValue10());
         return result;
      }
      public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> GetTestValue5()
      {
         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>();
         result.Create(new Ajuna.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8()});
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.node_template_runtime.EnumCall GetTestValue6()
      {
         MoneyPot_NetApiExt.Generated.Model.node_template_runtime.EnumCall result;
         result = new MoneyPot_NetApiExt.Generated.Model.node_template_runtime.EnumCall();
         result.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.node_template_runtime.Call>(), this.GetTestValue7());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.frame_system.pallet.EnumCall GetTestValue7()
      {
         MoneyPot_NetApiExt.Generated.Model.frame_system.pallet.EnumCall result;
         result = new MoneyPot_NetApiExt.Generated.Model.frame_system.pallet.EnumCall();
         result.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.frame_system.pallet.Call>(), this.GetTestValue8());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill GetTestValue8()
      {
         MoneyPot_NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill result;
         result = new MoneyPot_NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill();
         result.Value = this.GetTestValueU32();
         return result;
      }
      public Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> GetTestValue9()
      {
         Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>();
         result.Create(this.GetTestValueU32(), this.GetTestValueU32());
         return result;
      }
      public MoneyPot_NetApiExt.Generated.Model.frame_support.dispatch.EnumRawOrigin GetTestValue10()
      {
         MoneyPot_NetApiExt.Generated.Model.frame_support.dispatch.EnumRawOrigin result;
         result = new MoneyPot_NetApiExt.Generated.Model.frame_support.dispatch.EnumRawOrigin();
         result.Create(this.GetTestValueEnum<MoneyPot_NetApiExt.Generated.Model.frame_support.dispatch.RawOrigin>(), this.GetTestValueBaseVoid());
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestAgenda()
      {
         // Construct new Mockup client to test with.
         SchedulerControllerMockupClient mockupClient = new SchedulerControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         SchedulerControllerClient rpcClient = new SchedulerControllerClient(_httpClient, subscriptionClient);
         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>> mockupValue = this.GetTestValue2();
         Ajuna.NetApi.Model.Types.Primitive.U32 mockupKey = this.GetTestValueU32();

         Assert.IsTrue(await rpcClient.SubscribeAgenda(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetAgenda(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>> rpcResult = await rpcClient.GetAgenda(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
      public Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> GetTestValue12()
      {
         Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>();
         result.Create(this.GetTestValueU32(), this.GetTestValueU32());
         return result;
      }
      public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> GetTestValue13()
      {
         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> result;
         result = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>();
         result.Create(new Ajuna.NetApi.Model.Types.Primitive.U8[] {
                  this.GetTestValueU8()});
         return result;
      }
      [Test()]
      public async System.Threading.Tasks.Task TestLookup()
      {
         // Construct new Mockup client to test with.
         SchedulerControllerMockupClient mockupClient = new SchedulerControllerMockupClient(_httpClient);

         // Construct new subscription client to test with.
         var subscriptionClient = CreateSubscriptionClient();

         // Construct new RPC client to test with.
         SchedulerControllerClient rpcClient = new SchedulerControllerClient(_httpClient, subscriptionClient);
         Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> mockupValue = this.GetTestValue12();
         Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> mockupKey = this.GetTestValue13();

         Assert.IsTrue(await rpcClient.SubscribeLookup(mockupKey));

         // Save the previously generated mockup value in RPC service storage.
         bool mockupSetResult = await mockupClient.SetLookup(mockupValue, mockupKey);

         // Test that the expected mockup value was handled successfully from RPC service.
         Assert.IsTrue(mockupSetResult);
         var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
         Assert.IsTrue(await subscriptionClient.ReceiveNextAsync(cts.Token));

         Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> rpcResult = await rpcClient.GetLookup(mockupKey);

         // Test that the expected mockup value matches the actual result from RPC service.
         Assert.AreEqual(mockupValue.Encode(), rpcResult.Encode());
      }
   }
}
