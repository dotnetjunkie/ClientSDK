﻿using System;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.UnitTests.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UnitTests
{

	/// <summary>
	///This is a test class for APIConnectionTest and is intended
	///to contain all APIConnectionTest Unit Tests
	///</summary>
	[TestClass]
	public class ApiConnectionTest
	{
		// For test, because a valid uri is necessary 
		private const string Uri = "http://localhost/WI_143620/api/v1/";
		private const string CurrentDivision = "499156";

		IApiConnector _connector;
		ApiConnection _conn;

		#region Additional Test Config

		//Use TestInitialize to run code before running each test
		[TestInitialize]
		public void MyTestInitialize()
		{
			_connector = new ApiConnectorMock();
			_conn = new ApiConnection(_connector, Uri + CurrentDivision + "/crm/Accounts");
		}

		#endregion

		#region ApiConnection Constructor Tests

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void ApiConnection_Constructor_InitializeWithEmptyValues_Fails()
		{
			var constructor = new ApiConnection(null, string.Empty);
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void ApiConnection_Constructor_CreateWithEmptyConnector_Fails()
		{
			var constructor = new ApiConnection(null, "financial/GLAccounts");
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void ApiConnection_Constructor_InitializeWithEmptyEndpoint_Fails()
		{
			var constructor = new ApiConnection(null, string.Empty);
		}
		#endregion

		#region Get Tests
		[TestCategory("Unit Test")]
		[TestMethod]
		public void ApiConnection_GetEntityWithGuidSpecified_Succeeds()
		{
			_conn.GetEntity("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty);
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_GetEntity_WithoutGuidSpecified_Fails()
		{
			_conn.GetEntity("ID", string.Empty, string.Empty);
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_GetEntity_WithoutKeyNameSpecified_Fails()
		{
			_conn.GetEntity(string.Empty, "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty);
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_GetEntity_WithoutKeynameAndGuidSpecified_Fails()
		{
			_conn.GetEntity(string.Empty, string.Empty, string.Empty);
		}
		#endregion

		#region Post Tests
		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Post_TestWithoutPostData_Fails()
		{
			_conn.Post("");
		}

		[TestCategory("Unit Test")]
		[TestMethod]
		public void ApiConnection_Post_TestWithPostData_Succeeds()
		{
			_conn.Post("{Test}");
		}
		#endregion

		#region Put Tests
		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Put_WithoutData_Fails()
		{
			_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "");
		}

		[TestCategory("Unit Test")]
		[TestMethod]
		public void ApiConnection_Put_WithData_Succeeds()
		{
			_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata");
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Put_WithoutGuid_Fails()
		{
			_conn.Put("ID", "", "Testdata");
		}

		[TestCategory("Unit Test")]
		[TestMethod]
		public void ApiConnection_Put_WithGuid_Succeeds()
		{
			_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata");
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Put_WithoutDataAndGuid_Fails()
		{
			_conn.Put("ID", "", "");
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Put_WithoutDataAndGuidAndKeyname_Fails()
		{
			_conn.Put("", "", "");
		}

		[TestCategory("Unit Test")]
		[TestMethod]
		public void ApiConnection_Put_WithDataAndGuid_Succeeds()
		{
			_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "TestData");
		}
		#endregion

		#region Delete Tests
		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Delete_TestWithEmptyGuid_Fails()
		{
			_conn.Delete("ID", "");
		}

		[TestCategory("Unit Test")]
		[TestCategory("Unit Tests")]
		public void ApiConnectionDeleteTestWithGuidSucceeds()
		{
			_conn.Delete("ID", "GUID");
		}

		[TestCategory("Unit Test")]
		[TestMethod, ExpectedException(typeof(Exception))]
		public void ApiConnection_Delete_TestWithEmptyGuidAndNoKeyname_Fails()
		{
			_conn.Delete("", "");
		}
		#endregion

	}
}
