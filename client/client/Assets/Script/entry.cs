using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;
using System;

public class entry : MonoBehaviour {

	public Button ConnectBtn;
	public Button SendBtn;
	public InputField SendInput;
	public Text ResponseMsg;
	Socket socket;

	byte[] readBuff = new byte[1024];
	string recvstr = string.Empty;
	void Start () {

		ConnectBtn.onClick.AddListener(Connection);
		SendBtn.onClick.AddListener(SendMsg);
	}
	
	void Update()
	{
		ResponseMsg.text = recvstr;
	}

	public void Connection()
	{
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPAddress ip = IPAddress.Parse("127.0.0.1");
		IPEndPoint iPEnd = new IPEndPoint(ip, 8888);

		Debug.LogError("begin connect" );
		socket.BeginConnect(iPEnd, ConnectCallBack, socket);

	}

	public void ConnectCallBack(IAsyncResult async)
	{
		try
		{
			Socket conSo = (Socket)async.AsyncState;
			conSo.EndConnect(async);
			Debug.LogError("connect success " + socket.LocalEndPoint);

			conSo.BeginReceive(readBuff, 0, 1024, SocketFlags.None, ReceiveMsgCallBack, conSo);
		}
		catch (SocketException e)
		{
			Debug.LogError("connect fail" + e.ToString());
			throw;
		}
	}

	public void ReceiveMsgCallBack(IAsyncResult async)
	{
		try
		{
			Socket conSo = (Socket)async.AsyncState;
			int count = conSo.EndReceive(async);
			recvstr = System.Text.Encoding.Default.GetString(readBuff, 0, count);
			Debug.LogError("receive msg" + recvstr);
			conSo.BeginReceive(readBuff, 0, 1024, SocketFlags.None, ReceiveMsgCallBack, conSo);

		}
		catch (SocketException e)
		{
			Debug.LogError("receive fail" + e.ToString());
			throw;
		}
	}

	public void SendMsg()
	{
		byte[] sendMsg = System.Text.Encoding.Default.GetBytes(SendInput.text);
		socket.BeginSend(sendMsg, 0, sendMsg.Length, 0, SendCallBack, socket);
	}

	public void SendCallBack(IAsyncResult async)
	{
		try
		{
			Socket so = (Socket)async.AsyncState;
			int sendCount = so.EndSend(async);
			Debug.LogError("send end" + sendCount);
		}
		catch (SocketException e)
		{
			Debug.LogError("send fail" + e.ToString());
			throw;
		}
	}
}
