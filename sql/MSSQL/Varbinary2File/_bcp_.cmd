rem bcp "select asm_files.content from sys.assemblies asm join sys.assembly_files asm_files on asm_files.assembly_id = asm.assembly_id where asm.name = N'System.Drawing'" queryout "System.Drawing.dll" -S localhost -d ch -T -U sa -P 123
rem bcp "select asm_files.content from sys.assemblies asm join sys.assembly_files asm_files on asm_files.assembly_id = asm.assembly_id where asm.name = N'fn_RAMail_OL'" queryout "fn_RAMail_OL.dll" -S localhost -d ch -T -U sa -P 123
bcp "select ImageBody from dbo.refGoods where FullName = N'Goods_Copying_MixCO'" queryout "ImageBody" -S "test-robot-6.systtech.ru" -d "region_16_weekly_AUTOTEST-VM3_192.168.2.43" -T -U sa -P 123456