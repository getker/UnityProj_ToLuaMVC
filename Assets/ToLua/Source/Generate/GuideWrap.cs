﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GuideWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Guide), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("SetTarget", SetTarget);
		L.RegFunction("IsRaycastLocationValid", IsRaycastLocationValid);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("UICanvas", get_UICanvas, null);
		L.RegVar("MapCanvas", get_MapCanvas, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTarget(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				Guide obj = (Guide)ToLua.CheckObject<Guide>(L, 1);
				UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckObject(L, 2, typeof(UnityEngine.RectTransform));
				UnityEngine.Vector2 o = obj.SetTarget(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3)
			{
				Guide obj = (Guide)ToLua.CheckObject<Guide>(L, 1);
				UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckObject(L, 2, typeof(UnityEngine.RectTransform));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				UnityEngine.Vector2 o = obj.SetTarget(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Guide.SetTarget");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsRaycastLocationValid(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Guide obj = (Guide)ToLua.CheckObject<Guide>(L, 1);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Camera arg1 = (UnityEngine.Camera)ToLua.CheckObject(L, 3, typeof(UnityEngine.Camera));
			bool o = obj.IsRaycastLocationValid(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UICanvas(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Guide obj = (Guide)o;
			UnityEngine.Canvas ret = obj.UICanvas;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index UICanvas on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MapCanvas(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Guide obj = (Guide)o;
			UnityEngine.Canvas ret = obj.MapCanvas;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index MapCanvas on a nil value");
		}
	}
}

