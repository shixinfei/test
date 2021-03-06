if object_id(N'TestTable4Types', N'u') is not null
  drop table TestTable4Types
go

create table TestTable4Types
(
	Id bigint not null constraint pkTestTable4Types primary key,
	FVarChar varchar(256) null,
	FNVarChar nvarchar(256) null,
	FBit bit null,
	FDate date null,
	FTime time null,
	FDateTime datetime null,
	FDateTime2 datetime2 null,
	FSmallDateTime smalldatetime null,
	FDateTimeOffset datetimeoffset null,
	FNumeric_30_15 numeric(30, 15) null,
	FVarBinary_28 varbinary(28) null,
	FDecimal_7_6 decimal(7, 6) null
)
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'TestTable4Types')
                 and name=N'FNumeric_30_15')
  alter table TestTable4Types add FNumeric_30_15 numeric(30, 15) null
else
  print N'TestTable4Types.FNumeric_30_15 already exists!!!'
go

if not exists (select 1 from sys.objects where parent_object_id = object_id(N'TestTable4Types', N'u') and type = 'c' and name = N'CheckTestTable4TypesFNumeric_30_15')
	alter table TestTable4Types add constraint CheckTestTable4TypesFNumeric_30_15 check (FNumeric_30_15 between -79228162514264.337593543950335 and 79228162514264.337593543950335)

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'TestTable4Types')
                 and name=N'FVarBinary_28')
  alter table TestTable4Types add FVarBinary_28 varbinary(28) null
else
  print N'TestTable4Types.FVarBinary_28 already exists!!!'
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'TestTable4Types')
                 and name=N'FDecimal_7_6')
  alter table TestTable4Types add FDecimal_7_6 decimal(7, 6) null
else
  print N'TestTable4Types.FDecimal_7_6 already exists!!!'
go
