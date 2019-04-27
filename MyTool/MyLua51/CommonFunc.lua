--自定义函数接口

function f2(value1,value2)
	MyLua_OutPutLog("value1:"..value1.." value2:"..value2)
end



function rwSysQusetLog(nLogId,nProcess,nCostEmoney,nCostTmoney,nItem,nItemNum,nCostItem,nCostItemNum,nFlag,nUserId,sUserName)
	if sUserName == nil then
		sUserName = ""
	end
	local str = nLogId.." "..nProcess.." "..nCostEmoney.." "..nCostTmoney.." "..nItem.." "..nItemNum.." "..nCostItem.." "..nCostItemNum.." "..nFlag.." "..nUserId.." "..sUserName

	MyLua_OutPutLog(str)
end


function Interface(str)
	local t = MyLua_ToLuaData(str)

	MyLua_OutPutLog(type(t).." "..t[0].." "..t[1].." "..t[2])
	
end
