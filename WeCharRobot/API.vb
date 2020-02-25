Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading.Tasks


Friend Class API
		'应用ID
		Public Shared Property Auth_code() As Integer
		'应用logo
		Public Shared ReadOnly Property Imgbase64() As String
			Get
				'图片base64数据不能有data:image/png;base64,这段头部信息
				Dim Img As String = "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"
				Return Img
			End Get
		End Property

		#Region "动态链接库"

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_AcceptTransfer(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal from_wxid As String, ByVal json_msg As String) As IntPtr
		End Function


		<DllImport("car\coupler.dll")>
		Private Shared Function Api_AgreeFriendVerify(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal json_msg As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_AgreeGroupInvite(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal json_msg As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_AppendLogs(ByVal auth_code As Integer, ByVal msg1 As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_BuildingGroup(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal friends As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_DeleteFriend(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal friend_wxid As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetAppDirectory(ByVal auth_code As Integer) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetFriendList(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal is_refresh As Boolean) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetGroupList(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal is_refresh As Boolean) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetGroupMemberDetailInfo(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal member_wxid As String, ByVal is_refresh As Boolean) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetGroupMemberList(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal is_refresh As Boolean) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetLoggedAccountList(ByVal auth_code As Integer) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetRobotHeadimgurl(ByVal auth_code As Integer, ByVal robot_wxid As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_GetRobotName(ByVal auth_code As Integer, ByVal robot_wxid As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_Initialize(ByVal session As Integer, ByVal jsonStr As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_InviteInGroup(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal friend_wxid As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_ModifyFriendNote(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal friend_wxid As String, ByVal note As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_ModifyGroupName(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal group_name As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_ModifyGroupNotice(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal content As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_QuitGroup(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String) As IntPtr
		End Function

		<DllImport("car\coupler.dll")>
		Private Shared Function Api_ReloadPlug(ByVal auth_code As Integer) As IntPtr
		End Function
		'[DllImport("car\\coupler.dll")]
		'private static extern IntPtr Api_SendCardMsg(string QQ号, string AuthCode);
		'[DllImport("car\\coupler.dll")]
		'private static extern IntPtr Api_SendCollectedMsg(string QQ号, string AuthCode);
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendEmojiMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendFileMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendGroupMsgAndAt(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal group_wxid As String, ByVal member_wxid As String, ByVal member_name As String, ByVal msg As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendImageMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendLinkMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal title As String, ByVal text As String, ByVal target_url As String, ByVal pic_url As String, ByVal icon_url As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendMusicMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal name As String, ByVal type As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendTextMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal msg As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SendVideoMsg(ByVal auth_code As Integer, ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As IntPtr
		End Function
		<DllImport("car\coupler.dll")>
		Private Shared Function Api_SetFatal(ByVal auth_code As Integer) As IntPtr
		End Function

		#End Region

		#Region "接口方法调用"
		''' <summary>
		''' 接收好友转账
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="from_wxid">来源id</param>
		''' <param name="json_msg">请将事件原消息返回</param>
		''' <returns></returns>
		Public Shared Function AcceptTransfer(ByVal robot_wxid As String, ByVal from_wxid As String, ByVal json_msg As String) As Integer

			Dim intPtr As IntPtr = Api_AcceptTransfer(Auth_code, robot_wxid, from_wxid, json_msg)

			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 同意好友请求
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">哪个账号收到的好友验证，就填哪个账号的那个id号</param>
		''' <param name="json_msg"></param>
		''' <returns></returns>
		Public Shared Function AgreeFriendVerify(ByVal robot_wxid As String, ByVal json_msg As String) As Integer

			Dim intPtr As IntPtr = Api_AgreeFriendVerify(Auth_code, robot_wxid, json_msg)

			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 同意群聊邀请
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">哪个机器人收到的群聊邀请，就填那个机器人的ID号</param>
		''' <param name="json_msg">请传入事件的原消息</param>
		''' <returns></returns>
		Public Shared Function AgreeGroupInvite(ByVal robot_wxid As String, ByVal json_msg As String) As Integer

			Dim intPtr As IntPtr = Api_AgreeGroupInvite(Auth_code, robot_wxid, json_msg)

			Return CInt(intPtr)
		End Function

		''' <summary>
		''' 添加输出日志
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="msg1">日志内容</param>
		''' <returns></returns>
		Public Shared Function AppendLogs(ByVal msg1 As String) As Integer

			Dim intPtr As IntPtr = Api_AppendLogs(Auth_code, msg1)

			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 建立新群
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="friends">多个好友id，格式为：f1|f2|f3</param>
		''' <returns></returns>
		Public Shared Function BuildingGroup(ByVal robot_wxid As String, ByVal friends As String) As Integer

			Dim intPtr As IntPtr = Api_BuildingGroup(Auth_code, robot_wxid, friends)

			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 删除好友
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="friend_wxid">好友id</param>
		''' <returns></returns>
		Public Shared Function DeleteFriend(ByVal robot_wxid As String, ByVal friend_wxid As String) As Integer

			Dim intPtr As IntPtr = Api_DeleteFriend(Auth_code, robot_wxid, friend_wxid)

			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 取插件信息
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <returns></returns>
		Public Shared Function GetAppDirectory() As String
			Dim intPtr As IntPtr = Api_GetAppDirectory(Auth_code)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 取好友列表
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">如不填，则取的是所有登录账号的好友列表</param>
		''' <param name="is_refresh">为真将重新加载（注意切记不要频繁加载这里），不然将取缓存，默认为假</param>
		''' <returns></returns>
		Public Shared Function GetFriendList(ByVal robot_wxid As String, ByVal is_refresh As Boolean) As String
			Dim intPtr As IntPtr = Api_GetFriendList(Auth_code, robot_wxid, is_refresh)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 取群列表
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID，如不填，则取的是所有账号群列表</param>
		''' <param name="is_refresh">为真将重新加载（注意切记不要频繁加载这里），不然将取缓存，默认为假</param>
		''' <returns></returns>
		Public Shared Function GetGroupList(ByVal robot_wxid As String, ByVal is_refresh As Boolean) As String
			Dim intPtr As IntPtr = Api_GetGroupList(Auth_code, robot_wxid, is_refresh)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">已登账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <param name="member_wxid">群成员id</param>
		''' <param name="is_refresh">为真重新加载/为假取缓存（切勿频繁重新加载）默认为假</param>
		''' <returns></returns>
		Public Shared Function GetGroupMemberDetailInfo(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal member_wxid As String, ByVal is_refresh As Boolean) As String
			Dim intPtr As IntPtr = Api_GetGroupMemberDetailInfo(Auth_code, robot_wxid, group_wxid, member_wxid, is_refresh)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">已登账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <param name="is_refresh">为真将重新加载列表（注意切记不要频繁加载这里），不然将取缓存，默认为假</param>
		''' <returns></returns>
		Public Shared Function GetGroupMemberList(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal is_refresh As Boolean) As String
			Dim intPtr As IntPtr = Api_GetGroupMemberList(Auth_code, robot_wxid, group_wxid, is_refresh)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 取登录账号列表
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <returns></returns>
		Public Shared Function GetLoggedAccountList() As String
			Dim intPtr As IntPtr = Api_GetLoggedAccountList(Auth_code)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 取登录账号头像
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <returns></returns>
		Public Shared Function GetRobotHeadimgurl(ByVal robot_wxid As String) As String
			Dim intPtr As IntPtr = Api_GetRobotHeadimgurl(Auth_code, robot_wxid)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function
		''' <summary>
		''' 取登录账号昵称
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <returns></returns>
		Public Shared Function GetRobotName(ByVal robot_wxid As String) As String
			Dim intPtr As IntPtr = Api_GetRobotName(Auth_code, robot_wxid)

			Return Marshal.PtrToStringAnsi(intPtr)
		End Function

		''' <summary>
		''' 初始化
		''' </summary>
		''' <param name="session"></param>
		''' <param name="jsonStr"></param>
		''' <returns></returns>
		Public Shared Function Initialize(ByVal session As Integer, ByVal jsonStr As String) As Integer
			Dim intPtr As IntPtr = Api_Initialize(session, jsonStr)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 邀请加入群聊
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <param name="friend_wxid">好友id</param>
		''' <returns></returns>
		Public Shared Function InviteInGroup(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal friend_wxid As String) As Integer
			Dim intPtr As IntPtr = Api_InviteInGroup(Auth_code, robot_wxid, group_wxid, friend_wxid)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 修改好友备注
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="friend_wxid">好友id</param>
		''' <param name="note">新备注</param>
		''' <returns></returns>
		Public Shared Function ModifyFriendNote(ByVal robot_wxid As String, ByVal friend_wxid As String, ByVal note As String) As Integer
			Dim intPtr As IntPtr = Api_ModifyFriendNote(Auth_code, robot_wxid, friend_wxid, note)
			Return CInt(intPtr)
		End Function

		''' <summary>
		''' 修改群名称
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <param name="group_name">新的群名称</param>
		''' <returns></returns>
		Public Shared Function ModifyGroupName(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal group_name As String) As Integer
			Dim intPtr As IntPtr = Api_ModifyGroupName(Auth_code, robot_wxid, group_wxid, group_name)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 修改群公告
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <param name="content">群公告文字</param>
		''' <returns></returns>
		Public Shared Function ModifyGroupNotice(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal content As String) As Integer
			Dim intPtr As IntPtr = Api_ModifyGroupNotice(Auth_code, robot_wxid, group_wxid, content)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 退出群聊
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">账号id</param>
		''' <param name="group_wxid">群id</param>
		''' <returns></returns>
		Public Shared Function QuitGroup(ByVal robot_wxid As String, ByVal group_wxid As String) As Integer
			Dim intPtr As IntPtr = Api_QuitGroup(Auth_code, robot_wxid, group_wxid)
			Return CInt(intPtr)
		End Function

		''' <summary>
		''' 重载插件
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <returns></returns>
		Public Shared Function ReloadPlug() As Integer
			Dim intPtr As IntPtr = Api_ReloadPlug(Auth_code)
			Return CInt(intPtr)
		End Function

		''' <summary>
		''' 发送Emoji表情发送动态表情
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <param name="to_wxid">对方的id</param>
		''' <param name="path">文件全路径</param>
		''' <returns></returns>
		Public Shared Function SendEmojiMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As Integer
			Dim intPtr As IntPtr = Api_SendEmojiMsg(Auth_code, robot_wxid, to_wxid, path)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送文件
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <param name="to_wxid">对方的id</param>
		''' <param name="path">文件全路径</param>
		''' <returns></returns>
		Public Shared Function SendFileMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As Integer
			Dim intPtr As IntPtr = Api_SendFileMsg(Auth_code, robot_wxid, to_wxid, path)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送群消息并艾特
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <param name="group_wxid">对方的id</param>
		''' <param name="member_wxid">艾特那个成员的id</param>
		''' <param name="member_name">艾特那个成员的名字</param>
		''' <param name="msg">消息内容</param>
		''' <returns></returns>
		Public Shared Function SendGroupMsgAndAt(ByVal robot_wxid As String, ByVal group_wxid As String, ByVal member_wxid As String, ByVal member_name As String, ByVal msg As String) As Integer
			Dim intPtr As IntPtr = Api_SendGroupMsgAndAt(Auth_code, robot_wxid, group_wxid, member_wxid, member_name, msg)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送图片消息
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">机器人ID</param>
		''' <param name="to_wxid">对方的id</param>
		''' <param name="path">图片的文件的绝对路径</param>
		''' <returns></returns>

		Public Shared Function SendImageMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As Integer
			Dim intPtr As IntPtr = Api_SendImageMsg(Auth_code, robot_wxid, to_wxid, path)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送分享链接  分享链接，可以分享音乐链接，电影链接，美食链接
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">用哪个账号发这条消息</param>
		''' <param name="to_wxid">对方的id</param>
		''' <param name="title">链接标题</param>
		''' <param name="text">链接内容</param>
		''' <param name="target_url">跳转链接</param>
		''' <param name="pic_url">图片的链接</param>
		''' <param name="icon_url">图标的链接</param>
		''' <returns></returns>
		Public Shared Function SendLinkMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal title As String, ByVal text As String, ByVal target_url As String, ByVal pic_url As String, ByVal icon_url As String) As Integer
			Dim intPtr As IntPtr = Api_SendLinkMsg(Auth_code, robot_wxid, to_wxid, title, text, target_url, pic_url, icon_url)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送音乐分享,发送一个音乐消息，分享给你中意的那个人，type：0 随机模式 / 1 网易云音乐 / 2 酷狗音乐 / 3 QQ音乐 / 因乐库原因当前版本都为网易云音乐
		''' </summary>
		''' <param name="auth_code"></param>
		''' <param name="robot_wxid"></param>
		''' <param name="to_wxid"></param>
		''' <param name="name"></param>
		''' <param name="type"></param>
		''' <returns></returns>
		Public Shared Function SendMusicMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal name As String, ByVal type As String) As Integer
			Dim intPtr As IntPtr = Api_SendMusicMsg(Auth_code, robot_wxid, to_wxid, name, type)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送文本消息
		''' </summary>
		''' <param name="robot_wxid">用哪个账号发这条消息</param>
		''' <param name="to_wxid">对方的id，可以是好友或者群聊</param>
		''' <param name="msg">文本内容</param>
		''' <returns></returns>
		Public Shared Function SendTextMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal msg As String) As Integer
			Dim intPtr As IntPtr = Api_SendTextMsg(Auth_code, robot_wxid, to_wxid, msg)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 发送视频消息
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <param name="robot_wxid">用哪个账号发这条消息</param>
		''' <param name="to_wxid">对方的id</param>
		''' <param name="path">文件全路径</param>
		''' <returns></returns>
		Public Shared Function SendVideoMsg(ByVal robot_wxid As String, ByVal to_wxid As String, ByVal path As String) As Integer
			Dim intPtr As IntPtr = Api_SendVideoMsg(Auth_code, robot_wxid, to_wxid, path)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 开启错误捕获
		''' </summary>
		''' <param name="auth_code">应用ID</param>
		''' <returns></returns>
		Public Shared Function SetFatal() As Integer
			Dim intPtr As IntPtr = Api_SetFatal(Auth_code)
			Return CInt(intPtr)
		End Function
		''' <summary>
		''' 用于解析ison格式数据
		''' </summary>
		''' <param name="json"></param>
		''' <returns></returns>
		Public Shared Function JsonMsg(ByVal json As String) As JObject
			Try
				Dim jo As JObject = CType(JsonConvert.DeserializeObject(json), JObject)
				Return jo
			Catch
				Return Nothing
			End Try

		End Function

		''' <summary>
		''' 根据ID查好友昵称
		''' </summary>
		''' <param name="robot_wxid"></param>
		''' <param name="from_wxid"></param>
		''' <returns></returns>
		Public Shared Function nickname(ByVal robot_wxid As String, ByVal from_wxid As String) As String
			Dim Ajson As String = GetFriendList(robot_wxid, True)
			Try
				Dim jA As JArray = CType(JsonConvert.DeserializeObject(Ajson), JArray)
				For i As Integer = 0 To jA.Count - 1
					If jA(i)("wxid").ToString() = from_wxid Then
						Return jA(i)("nickname").ToString()
					End If
				Next i
			Catch
			End Try

			Return "微信用户"
		End Function

		#End Region

	End Class
	Public Class Student
		Public Property name() As String
		Public Property desc() As String
		Public Property author() As String
		Public Property version() As String
		Public Property api_version() As String
		Public Property menu_title() As String
		Public Property cover_base64() As String
		Public Property developer_key() As String
	End Class





