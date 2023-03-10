//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.18444
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using Toast.Internal;

[TestFixture()]
public class JSONTest
{
	[Test()]
	public void CreateJSONNodeTest()
	{
		JSONObject json = new JSONObject();
		json ["paymentSeq"] = "2014092310000073";
		json ["itemSeq"].AsDouble = 1000002;
		json ["purchaseToken"] = "NsKv0etzBGJrHThu2UE8j5t2uAC-utPzwKyFOCOWqA7QJEb9XE8PqHBlwGOGVINhH76k3kt3vryah_IgDrd8_Q";

		string paymentSeq = json["paymentSeq"];
		Assert.AreEqual ("2014092310000073", paymentSeq);
	}

	[Test()]
	public void CreateJSONArrayTest()
	{
        JSONObject json = new JSONObject();
		json ["paymentSeq"] = "2014092310000073";
		json ["itemSeq"].AsDouble = 1000002;
		json ["purchaseToken"] = "NsKv0etzBGJrHThu2UE8j5t2uAC-utPzwKyFOCOWqA7QJEb9XE8PqHBlwGOGVINhH76k3kt3vryah_IgDrd8_Q";

		JSONArray root = new JSONArray ();
		root [0] = json;
		root [1] = json;

		Assert.AreEqual (2, root.Count);
	}

	[Test()]
	public void ParseJSONTest()
	{
		string response = "{\"paymentSeq\":\"2014092310000073\"}";
		JSONNode root = JSON.Parse(response);

		string paymentSeq = root["paymentSeq"];
		Assert.AreEqual ("2014092310000073",  paymentSeq);
	}
}


