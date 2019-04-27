
module("CheckLog", package.seeall)


g_nLogId = 1111


local nLogId = 2222

function f1()
	MyLua_OutPutLog(nLogId)
end


g_Table = {
	t = {
		1,
		x = 100,
	},
}


f1(nLogId)

f2(g_nLogId,3)

rwSysQusetLog(12315,1000,0,0,1500540,1,0,0,0,1000001)



Interface("MyValue")