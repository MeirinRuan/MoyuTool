

package.path= MyNLua_GetCurrentPath().."\\Nlua\\?.lua;"..package.path
MyNLua_OutPutLog(package.path)

require "CheckLog"

if nLogId then
	MyNLua_OutPutLog(nLogId)
end

MyNLua_OutPutLog("--------------end1-------------")

if g_nLogId then
	MyNLua_OutPutLog(g_nLogId)
end

MyNLua_OutPutLog("--------------end2-------------")

if CheckLog.nLogId then
	MyNLua_OutPutLog(nLogId)
end

MyNLua_OutPutLog("--------------end3-------------")

if CheckLog.g_nLogId then
	MyNLua_OutPutLog(g_nLogId)
end


MyNLua_OutPutLog("--------------end4-------------")