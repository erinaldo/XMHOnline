 -------- 创建类别表------------
USE [XMHOnlineSolution]
GO

/****** Object:  Table [prd].[PrdType]    Script Date: 06/23/2016 10:49:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
---   drop table prd.[ManuPrdType]
CREATE TABLE [prd].[ManuPrdType](
	[ManuPrdTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ManuPrdTypeCode] [varchar](50) NOT NULL,
	[ManuPrdTypeName] [varchar](50) NOT NULL,
	[ParentID] [int] NOT NULL,
 CONSTRAINT [PK_ManuPrdType] PRIMARY KEY CLUSTERED 
(
	[ManuPrdTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [prd].[ManuPrdType] ADD  CONSTRAINT [DF_ManuPrdType_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
 -------- 创建类别表------------
 
 
 /*
数据表 [prd.PrdType]  按选择条件查询
*/
--=====================================================================
--- drop PROCEDURE [prd].[GetDataManuPrdType]
CREATE PROCEDURE [prd].[GetDataManuPrdType]
AS
BEGIN
	SELECT 
		ManuPrdTypeID,ManuPrdTypeCode,ManuPrdTypeName,ParentID
	FROM prd.ManuPrdType
END


GO


/*
数据表 [prd.PrdTypes]  删除
*/
--=====================================================================
--- drop PROCEDURE [prd].[DeleteManuPrdType]
CREATE PROCEDURE [prd].[DeleteManuPrdType]
(
	@ManuPrdTypeID int   
)
AS
BEGIN
	Delete from  prd.ManuPrdType
	Where
	(ManuPrdTypeID=@ManuPrdTypeID)
	exec prd.PM_DelChildManuPrdType @ManuPrdTypeID
END


GO

--******************************************************************
--作者:金优富
--时间:2006-7-28
--描述
/*
递归删除之模块
*/
--******************************************************************
-- drop  PROCEDURE [prd].[PM_DelChildManuPrdType]
CREATE  PROCEDURE [prd].[PM_DelChildManuPrdType]
(
	@ParentID  bigint
)
AS
declare @child_ids varchar(1000) --子module_ID列表
set @child_ids =''
declare @tmp_code varchar(50)
declare @tmp_id int
declare @i int
set @i=0
select @child_ids=@child_ids+ cast(ManuPrdTypeID as varchar(32))+ ',' from ManuPrdType where ParentID=@ParentID
while(len(@child_ids)>1)
begin
     set @i=charindex(',',@child_ids,0)
     if(@i>1)
     begin
        set @tmp_code=substring(@child_ids,1,@i-1)
        set @child_ids=stuff(@child_ids,1,@i,'')
        set @tmp_id=cast(@tmp_code as int)
        delete from ManuPrdType where ManuPrdTypeID=@tmp_id
        exec  prd.PM_DelChildPrdType @tmp_id
     end 
end


GO

/*
数据表 [prd.ManuPrdType]  更新
*/
--=====================================================================
-- drop PROCEDURE [prd].[UpdateManuPrdType]
CREATE PROCEDURE [prd].[UpdateManuPrdType]
(
	@ManuPrdTypeID int   , 
	@ManuPrdTypeCode varchar (50),
	@ManuPrdTypeName varchar (50),
	@ParentID int
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuPrdType
	SET 
		ManuPrdTypeCode=@ManuPrdTypeCode,
		ManuPrdTypeName=@ManuPrdTypeName,
		ParentID=@ParentID
	Where  ManuPrdTypeID=@ManuPrdTypeID
END


GO
---select * from prd.ManuPrdType
/*
数据表 [prd.PrdType]  添加
*/
--=====================================================================
-- drop PROCEDURE [prd].[InsertManuPrdType]
CREATE PROCEDURE [prd].[InsertManuPrdType]
(
	@ManuPrdTypeID int   out, 
	@ManuPrdTypeCode varchar (50)  ,
	@ManuPrdTypeName varchar (50)  ,
	@ParentID int   
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ManuPrdType
	( 
		ManuPrdTypeCode,
		ManuPrdTypeName,
		ParentID
	)
	Values
	( 
		@ManuPrdTypeCode,
		@ManuPrdTypeName,
		@ParentID
	)
	Set @ManuPrdTypeID=SCOPE_IDENTITY()--返回标识值
END


GO

/*
数据表 [prd.PrdType]  按选择条件查询
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataManuPrdTypeByParentID]
Create PROCEDURE prd.GetDataManuPrdTypeByParentID
(
	@ParentID int   
)
AS
BEGIN
	SELECT 
		*
	FROM prd.ManuPrdType
	WHERE 
		(ParentID=@ParentID)
END
GO



---------------------------------------------
---------------------------------------------物料

USE [XMHOnlineSolution]
GO

/****** Object:  Table [prd].[ManuProduct]    Script Date: 06/24/2016 17:05:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
---  drop TABLE [prd].[ManuProduct]
CREATE TABLE [prd].[ManuProduct](
	[PrdID] [int] IDENTITY(1,1) NOT NULL,
	[PrdTypeID] [int] NULL,
	[PrdCode] [varchar](100) NOT NULL,
	[PrdName] [varchar](100) NULL,
	[PrdSpec] [varchar](300) NULL,
	[Model] [varchar](100) NULL,
	[Surface] [varchar](100) NULL,
	[Manufacturer] [varchar](100) NULL,
	[DWGNo] [varchar](100) NULL,
	[AssistantCode] [varchar](50) NULL,
	[TaxfreeFlag] [bit] NULL,
	[RohsFlag] [bit] NULL,
	[RohsRequireFlag] [bit] NULL,
	[ICSolution] [varchar](200) NULL,
	[PrdWeight] [numeric](18, 6) NULL,
	[SaleFlag] [bit] NOT NULL,
	[UnitID] [int] NULL,
	[DateRegister] [datetime] NULL,
	[FileCode] [varchar](50) NULL,
	[RegisterPsn] [varchar](50) NULL,
	[VersionCode] [varchar](50) NULL,
	[VersionRecord] [varchar](max) NULL,
	[MinPackingQty] [numeric](18, 4) NULL,
	[CostPrice] [money] NULL,
	[SalePrice] [money] NULL,
	[Supplier] [varchar](200) NULL,
	[SupplierPrdCode] [varchar](max) NULL,
	[Buyer] [varchar](200) NULL,
	[ManufProcessList] [varchar](max) NULL,
	[PurchasePriceInfor] [varchar](max) NULL,
	[ManufProcessCostPriceList] [varchar](max) NULL,
	[ManufDays] [int] NULL,
	[PrdSetFlag] [bit] NULL,
	[PrdSetCount] [int] NULL,
	[FileCount] [int] NULL,
	[SalePriceFileCount] [int] NULL,
	[ImgCount] [int] NULL,
	[ManufImgCount] [int] NULL,
	[StopFlag] [bit] NULL,
	[URL] [varchar](50) NULL,
	[Memo] [varchar](500) NULL,
	[CustomFlag] [bit] NULL,
 CONSTRAINT [PK_ManuProduct_3] PRIMARY KEY CLUSTERED 
(
	[PrdID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrdID' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'PrdID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'料号' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'PrdCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品名称' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'PrdName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号及规格' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'PrdSpec'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'Manufacturer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保税材料' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'TaxfreeFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成品' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'SaleFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计量单位' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'UnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作成日期' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'DateRegister'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件编号' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'FileCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作成' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'RegisterPsn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本号' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'VersionCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变更履历' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'VersionRecord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小包装量' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'MinPackingQty'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本单价' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'CostPrice'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'Supplier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单价信息' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'ManufProcessList'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成天数' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct', @level2type=N'COLUMN',@level2name=N'ManufDays'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品' , @level0type=N'SCHEMA',@level0name=N'prd', @level1type=N'TABLE',@level1name=N'ManuProduct'
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_RohsFlag]  DEFAULT ((0)) FOR [RohsFlag]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_RohsRequireFlag]  DEFAULT ((0)) FOR [RohsRequireFlag]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_SaleFlag_1]  DEFAULT ((0)) FOR [SaleFlag]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_PrdSetFlag]  DEFAULT ((0)) FOR [PrdSetFlag]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_SetPrdCount]  DEFAULT ((0)) FOR [PrdSetCount]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_FileCount_1]  DEFAULT ((0)) FOR [FileCount]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_ImgCount_1]  DEFAULT ((0)) FOR [ImgCount]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_ManufImgCount_1]  DEFAULT ((0)) FOR [ManufImgCount]
GO

ALTER TABLE [prd].[ManuProduct] ADD  CONSTRAINT [DF_ManuProduct_StopFlag]  DEFAULT ((0)) FOR [StopFlag]
GO





--=====================================================================
--作者:金优富
--时间:2013-9-21 17:05:16
--描述
/*
数据表 [prd.Product]  删除
*/
--=====================================================================
--   drop  PROCEDURE prd.DeleteManuProduct
Create PROCEDURE prd.DeleteManuProduct
(
	@PrdID int   
)
AS
BEGIN
	Delete from  prd.ManuProduct
	Where
	(PrdID=@PrdID)	
END

GO


/*
数据表 [prd.Product]  按选择自由分页查询
*/
--=====================================================================

CREATE PROCEDURE [prd].[GetDataManuProductPagesFreeSearch]
(
	@PageIndex int ,
	@PageSize int,
	@RecordCount int  out,
	@WhereClause nvarchar(MAX)
)
AS
BEGIN
	declare @sql nvarchar(MAX)
	set @sql='select @RecordCount=count(*) from prd.ManuProduct a where (1=1) '+@WhereClause
	exec sp_executesql @sql,N'@RecordCount int output',@RecordCount output
	Set @sql='Select 
			a.*,general.F_GetUnitUnitName(UnitID) as UnitName,
			prd.F_GetPrdTypePrdTypeName(PrdTypeID) as PrdTypeName 
		from  (  select *,ROW_NUMBER() OVER(ORDER BY PrdID ASC) AS RowNum From prd.ManuProduct a  Where (1=1) '+@WhereClause+' ) a  WHERE  RowNum Between '+cast(((@PageIndex-1) *@PageSize+1) as varchar(32))+' and '+cast( (@PageIndex*@PageSize) as varchar(32))
	EXEC(@sql)
END

GO

/*
数据表 [prd.PrdType]  PrdTypeName标值函数
*/
--=====================================================================
-- drop FUNCTION prd.F_GetManuPrdTypePrdTypeName
CREATE FUNCTION prd.F_GetManuPrdTypePrdTypeName
(
	@ManuPrdTypeID int 
)
RETURNS
varchar (50)
AS
BEGIN
	DECLARE @rut varchar (50)
	SELECT Top 1 @rut=ManuPrdTypeName FROM  prd.ManuPrdType WHERE ManuPrdTypeID=@ManuPrdTypeID
	RETURN @rut
END
GO



/*
数据表 [prd.Product]  按选择条件查询
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataManuProduct]
CREATE PROCEDURE [prd].[GetDataManuProduct]
AS
BEGIN
	SELECT 
		*,
		general.F_GetUnitUnitName(UnitID) as UnitName,
		prd.F_GetManuPrdTypePrdTypeName(PrdTypeID) as PrdTypeName
	FROM prd.ManuProduct 
END

GO


/*
数据表 [prd.Product]  按选择条件查询
*/
--=====================================================================

CREATE PROCEDURE [prd].[GetDataManuProductByPrdID]
(
	@PrdID int
)
AS
BEGIN
	SELECT 
		*,
		general.F_GetUnitUnitName(UnitID) as UnitName, 
		[prd].[F_GetPrdTypeTreePrdTypeName](PrdTypeID) as PrdTypeName
	FROM prd.ManuProduct 
	where PrdID=@PrdID 
END

GO


/*
数据表 [prd.ManuPrdType]  PrdTypeName标值函数
*/
--=====================================================================
--  drop FUNCTION [prd].[F_GetManuPrdTypeTreePrdTypeName]
CREATE FUNCTION [prd].[F_GetManuPrdTypeTreePrdTypeName]
(
	@ManuPrdTypeID int 
)
RETURNS
varchar (500)
AS
BEGIN
	DECLARE @ManuPrdTypeName varchar (50);
	declare @ParentID int;
	SELECT  @ManuPrdTypeName=ManuPrdTypeName,@ParentID=ParentID FROM  prd.ManuPrdType WHERE ManuPrdTypeID=@ManuPrdTypeID
	if(@ParentID>0)
	begin
		return  [prd].[F_GetPrdTypeTreePrdTypeName](@ParentID)+'>'+@ManuPrdTypeName
	end
	return @ManuPrdTypeName

END
GO


/*
数据表 [prd.Product]  参数查询
*/
--=====================================================================
--  drop PROCEDURE prd.GetParmManuProductMaxPrdCode
CREATE PROCEDURE prd.GetParmManuProductMaxPrdCode
(
	@PrdName varchar (100)  ,
	@PrdCode varchar (100)   out
)
AS
BEGIN
	SELECT 
		@PrdCode=max(PrdCode)
	FROM prd.ManuProduct
	WHERE 
		(PrdName=@PrdName)
	if(@PrdCode is null) set @PrdCode=N''
END

GO




--=====================================================================
--作者:金优富
--时间:2013-9-21 17:06:46
--描述
/*
数据表 [prd.Product]  按选择条件查询
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataManuProductByPrdTypeID]
CREATE PROCEDURE [prd].[GetDataManuProductByPrdTypeID]
(
	@PrdTypeID int
)
AS
BEGIN
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.ManuProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where PrdTypeID =@PrdTypeID 
END

GO

/*
数据表 [prd.ManuProduct]  按选择条件查询
*/
--=====================================================================
--  drop PROCEDURE [prd].[GetDataManuProductByAssistantCode]
CREATE PROCEDURE [prd].[GetDataManuProductByAssistantCode]
(
	@AssistantCode varchar(50)
)
AS
BEGIN
	SELECT 
		*, 
		general.F_GetUnitUnitName(UnitID) as UnitName
	FROM prd.ManuProduct 
	where AssistantCode like '%'+@AssistantCode+'%'
END

GO

----------------

--=====================================================================
--作者:金优富
--时间:2014/3/17 8:24:18
--描述
/*
数据表 [prd.Product]  添加
*/
--=====================================================================
--  drop PROCEDURE prd.InsertManuProduct
CREATE PROCEDURE prd.InsertManuProduct
(
	@PrdID int   out,
	@PrdTypeID int,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (300)  ,
	@Model varchar(100),
	@Surface varchar(100), 
	@Manufacturer varchar(100),
	@AssistantCode varchar(50), 
	@DWGNo varchar(100),
	@TaxfreeFlag bit,
	@RohsFlag bit,
	@RohsRequireFlag bit,
	@ICSolution varchar(200),
	@PrdWeight numeric(18,6),
	@SaleFlag bit   ,
	@UnitID int   , 
	@DateRegister datetime   ,
	@FileCode varchar (50)  ,
	@RegisterPsn varchar (50)  ,
	@VersionCode varchar (50)  ,
	@VersionRecord varchar (MAX) ,
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ManuProduct
	(
		PrdTypeID,
		PrdCode,
		PrdName,
		PrdSpec,	
		Model,
		Surface, 
		Manufacturer,	
		AssistantCode, 	
		DWGNo,
		TaxfreeFlag,
		RohsFlag,
		RohsRequireFlag,
		ICSolution,
		PrdWeight,
		SaleFlag,
		UnitID,
		DateRegister,
		FileCode,
		RegisterPsn,
		VersionCode,
		VersionRecord,
		MinPackingQty, 
		URL,
		Memo,
		CustomFlag,
		StopFlag
	)
	Values
	(
		@PrdTypeID,
		@PrdCode,
		@PrdName,
		@PrdSpec,
		@Model,
		@Surface, 
		@Manufacturer,
		@AssistantCode, 
		@DWGNo,
		@TaxfreeFlag,
		@RohsFlag,
		@RohsRequireFlag,
		@ICSolution,
		@PrdWeight,
		@SaleFlag,
		@UnitID,
		@DateRegister,
		@FileCode,
		@RegisterPsn,
		@VersionCode,
		@VersionRecord,
		@MinPackingQty, 
		@URL,
		@Memo,
		@CustomFlag,
		@StopFlag
	)
	Set @PrdID=SCOPE_IDENTITY()--返回标识值
END
GO




--=====================================================================
--作者:金优富
--时间:2014/3/16 22:04:09
--描述
/*
数据表 [prd.Product]  添加
*/
--=====================================================================
--- drop  PROCEDURE prd.InsertManuProductForImport
CREATE PROCEDURE prd.InsertManuProductForImport
(
	@PrdID int   out,
	@PrdTypeID int,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (300)  ,
	@Model varchar(100),	
	@Surface varchar(100), 
	@Manufacturer varchar(100),
	@AssistantCode varchar(50), 
	@DWGNo varchar(100),
	@TaxfreeFlag bit,
	@RohsFlag bit,
	@RohsRequireFlag bit,
	@PrdWeight numeric(18,6),
	@SaleFlag bit   ,
	@UnitID int ,  
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ManuProduct
	(
		PrdTypeID,
		PrdCode,
		PrdName,
		PrdSpec,
		Model,		
		Surface, 
		Manufacturer,
		AssistantCode, 
		DWGNo,
		TaxfreeFlag,
		RohsFlag,
		RohsRequireFlag,
		PrdWeight,
		SaleFlag,
		UnitID, 
		MinPackingQty, 
		URL,
		Memo,
		CustomFlag,
		StopFlag
	)
	Values
	(
		@PrdTypeID,
		@PrdCode,
		@PrdName,
		@PrdSpec,	
		@Model,
		@Surface, 
		@Manufacturer,
		@AssistantCode, 
		@DWGNo,
		@TaxfreeFlag,
		@RohsFlag,
		@RohsRequireFlag, 
		@PrdWeight,
		@SaleFlag,
		@UnitID, 
		@MinPackingQty, 
		@URL,
		@Memo,
		@CustomFlag,
		@StopFlag
	)
	Set @PrdID=SCOPE_IDENTITY()--返回标识值
END

GO







--=====================================================================
--作者:金优富
--时间:2014/3/17 8:24:53
--描述
/*
数据表 [prd.Product]  更新
*/
--=====================================================================
---  drop PROCEDURE prd.UpdateManuProduct
CREATE PROCEDURE prd.UpdateManuProduct
(
	@PrdID int   ,
	@PrdTypeID int,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (300)  ,
	@Model varchar(100),
	@Surface varchar(100), 
	@Manufacturer varchar(100),
	@AssistantCode varchar(50), 
	@DWGNo varchar(100),
	@TaxfreeFlag bit,
	@RohsFlag bit,
	@RohsRequireFlag bit,
	@ICSolution varchar(200),
	@PrdWeight numeric(18,6),
	@SaleFlag bit   ,
	@UnitID int   ,
	@DateRegister datetime   ,
	@FileCode varchar (50)  ,
	@RegisterPsn varchar (50)  ,
	@VersionCode varchar (50)  ,
	@VersionRecord varchar (MAX),
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit

)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuProduct
	SET
		PrdTypeID=@PrdTypeID,
		PrdCode=@PrdCode,
		PrdName=@PrdName,
		PrdSpec=@PrdSpec,
		Model=@Model,
		Surface=@Surface, 
		Manufacturer=@Manufacturer,
		AssistantCode=@AssistantCode , 
		DWGNo =@DWGNo ,
		TaxfreeFlag=@TaxfreeFlag,
		RohsFlag=@RohsFlag,
		RohsRequireFlag=@RohsRequireFlag,
		ICSolution=@ICSolution,
		PrdWeight=@PrdWeight,
		SaleFlag=@SaleFlag,
		UnitID=@UnitID,
		DateRegister=@DateRegister,
		FileCode=@FileCode,
		RegisterPsn=@RegisterPsn,
		VersionCode=@VersionCode,
		VersionRecord=@VersionRecord,
		MinPackingQty=@MinPackingQty, 
		URL=@URL,
		Memo=@Memo,
		CustomFlag=@CustomFlag,
		StopFlag=@StopFlag
	Where  (PrdID=@PrdID) 
	

END 

GO

---- select * from prd.ManuProduct

/*
数据表 [prd.ManuProduct]  更新
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateManuProductForPrdTypeID
CREATE PROCEDURE prd.UpdateManuProductForPrdTypeID
(
	@PrdID int  , 
	@PrdTypeID int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuProduct
	SET
		PrdTypeID=@PrdTypeID
	where PrdID=@PrdID
END
--- select * from prd.ManuProduct


--=====================================================================
--作者:金优富
--时间:2014/3/16 22:04:58
--描述
/*
数据表 [prd.Product]  更新
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateManuProductForImport
CREATE PROCEDURE prd.UpdateManuProductForImport
(
	@PrdID int   ,	
	@PrdTypeID int,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (300)  ,	
	@Model varchar(100),
	@Surface varchar(100), 
	@Manufacturer varchar(100),
	@AssistantCode varchar(50), 
	@DWGNo varchar(100),
	@TaxfreeFlag bit,
	@RohsFlag bit,
	@RohsRequireFlag bit,
	@PrdWeight numeric(18,6),
	@SaleFlag bit   ,
	@UnitID int,	 
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuProduct
	SET
		PrdTypeID=@PrdTypeID,
		PrdCode=@PrdCode,
		PrdName=@PrdName,
		PrdSpec=@PrdSpec,
		Model=@Model,
		Surface=@Surface, 
		Manufacturer=@Manufacturer,
		AssistantCode=@AssistantCode , 
		DWGNo =@DWGNo ,
		TaxfreeFlag=@TaxfreeFlag,
		RohsFlag=@RohsFlag,
		RohsRequireFlag=@RohsRequireFlag,
		PrdWeight=@PrdWeight,
		SaleFlag=@SaleFlag,
		UnitID=@UnitID, 
		MinPackingQty=@MinPackingQty, 
		URL=@URL,
		Memo=@Memo,
		CustomFlag=@CustomFlag,
		StopFlag=@StopFlag
	Where  (PrdID=@PrdID) 
END 

GO


/*
数据表 [prd.InsertManuProductForPrdSet]  添加
*/
--=====================================================================
-- drop PROCEDURE prd.InsertManuProductForPrdSet
CREATE PROCEDURE prd.InsertManuProductForPrdSet
(
	@PrdID int   out,
	@PrdTypeID int   ,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (200)  ,
	@Model varchar (100)  ,
	@AssistantCode varchar (50)  ,
	@UnitID int
)
AS
BEGIN
	SET NOCOUNT ON
	declare @PrdSetFlag bit;
	set @PrdSetFlag=1;
	INSERT prd.ManuProduct
	(
		PrdTypeID,
		PrdCode,
		PrdName,
		PrdSpec,
		Model,
		AssistantCode,
		UnitID,
		PrdSetFlag
	)
	Values
	(
		@PrdTypeID,
		@PrdCode,
		@PrdName,
		@PrdSpec,
		@Model,
		@AssistantCode,
		@UnitID,
		@PrdSetFlag
	)
	Set @PrdID=SCOPE_IDENTITY()--返回标识值
END

GO


/*
数据表 [prd.Product]  更新
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateManuProductForPrdSet
CREATE PROCEDURE prd.UpdateManuProductForPrdSet
(
	@PrdID int   ,
	@PrdTypeID int   ,
	@PrdCode varchar (100)  ,
	@PrdName varchar (100)  ,
	@PrdSpec varchar (200)  ,
	@Model varchar (100)  , 
	@AssistantCode varchar (50)  ,
	@UnitID int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuProduct
	SET
		PrdTypeID=@PrdTypeID,
		PrdCode=@PrdCode,
		PrdName=@PrdName,
		PrdSpec=@PrdSpec,
		Model=@Model, 
		AssistantCode=@AssistantCode,
		UnitID=@UnitID
	Where  (PrdID=@PrdID) 
END

GO


--------

/*
类型关系表
*/
-- drop TABLE [prd].[ManuProductTypeProRelation]
CREATE TABLE [prd].[ManuProductTypeProRelation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrdIDSrc] [int]  default(-1),
	[PrdIDDesc] [int]  default(-1)
)ON [PRIMARY] 
---- 相关操作
--增加
数据表 [prd.ManuProductTypeProRelation]  添加
*/
--=====================================================================
 -- drop  PROCEDURE prd.InsertManuProductTypeProRelation
CREATE PROCEDURE prd.InsertManuProductTypeProRelation
(
	@ID int  out,
	@PrdIDSrc int   ,
	@PrdIDDesc int   
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ManuProductTypeProRelation
	(
		PrdIDSrc,
		PrdIDDesc
	)
	Values
	(
		@PrdIDSrc,
		@PrdIDDesc
	)
	Set @ID=SCOPE_IDENTITY()--返回标识值
END

/*
数据表 [prd.ManuProductTypeProRelation]  删除
*/
--=====================================================================

CREATE PROCEDURE prd.DeleteManuProductTypeProRelation
(
	@ID int   
)
AS
BEGIN
	Delete from  prd.ManuProductTypeProRelation
	Where
	(ID=@ID)
END

/*
数据表 [prd.ManuProductTypeProRelation]  按选择条件查询
*/
--=====================================================================
-- drop PROCEDURE prd.GetDataManuProductTypeProRelation
CREATE PROCEDURE prd.GetDataManuProductTypeProRelation
AS
BEGIN
	SELECT 
		a1.ID ,a1.PrdIDSrc ,a2.ManuPrdTypeCode as SrcTypeCode,a2.ManuPrdTypeName as SrcTypeName,
		a1.PrdIDDesc ,a3.ManuPrdTypeName as DescTypeName,a3.ManuPrdTypeCode  as DescTypeCode
	FROM prd.ManuProductTypeProRelation a1
	inner join prd.ManuPrdType a2 on a1.PrdIDSrc = a2.ManuPrdTypeID
	inner join prd.ManuPrdType a3 on a1.PrdIDDesc = a3.ManuPrdTypeID
END



/*
物料属性类别表
*/
-- drop TABLE [prd].[ManuProductTypePro]
CREATE TABLE [prd].[ManuProductTypePro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrdID] int default(-1),
	[ProType1] int default(-1),
	[ProType2] int  default(-1),
	[ProType3] int  default(-1),
	[ProType4] int  default(-1),
	[ProType5] int  default(-1),
	[ProType6] int  default(-1),
	[ProType7] int  default(-1)

		CONSTRAINT [PK_ManuProduct_PrdID] PRIMARY KEY CLUSTERED 
	(
	[PrdID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO
-- select * from [prd].[ManuProductTypePro]


/*
数据表 [prd.ManuProductTypePro]  添加
*/
--=====================================================================

CREATE PROCEDURE prd.InsertManuProductTypePro
(
	@PrdID int   ,
	@ProType1 int   ,
	@ProType2 int   ,
	@ProType3 int   ,
	@ProType4 int   ,
	@ProType5 int   ,
	@ProType6 int   ,
	@ProType7 int   
)
AS
declare @prd_id bigint
select @prd_id = PrdID from prd.ManuProductTypePro where PrdID = @PrdID;
if (@prd_id > 0)
	BEGIN
		EXEC prd.UpdateManuProductTypePro @PrdID ,@ProType1,@ProType2,@ProType3,@ProType4,@ProType5,@ProType6,@ProType7
	END
ELSE
	BEGIN	
		INSERT prd.ManuProductTypePro
		(
			PrdID,
			ProType1,
			ProType2,
			ProType3,
			ProType4,
			ProType5,
			ProType6,
			ProType7
		)
		Values
		(
			@PrdID,
			@ProType1,
			@ProType2,
			@ProType3,
			@ProType4,
			@ProType5,
			@ProType6,
			@ProType7
		)
	END


/*
数据表 [prd.ManuProductTypePro]  更新
*/
--=====================================================================
-- DROP PROCEDURE prd.UpdateManuProductTypePro
CREATE PROCEDURE prd.UpdateManuProductTypePro
(
	@PrdID int   ,
	@ProType1 int   ,
	@ProType2 int   ,
	@ProType3 int   ,
	@ProType4 int   ,
	@ProType5 int   ,
	@ProType6 int   ,
	@ProType7 int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ManuProductTypePro
	SET
		ProType1=@ProType1,
		ProType2=@ProType2,
		ProType3=@ProType3,
		ProType4=@ProType4,
		ProType5=@ProType5,
		ProType6=@ProType6,
		ProType7=@ProType7
	WHERE 	PrdID=@PrdID
END

/*
数据表 [prd.ManuProductTypePro]  删除
*/
--=====================================================================
-- drop PROCEDURE prd.DeleteManuProductTypePro
CREATE PROCEDURE prd.DeleteManuProductTypePro
(
	@PrdID int   
)
AS
BEGIN
	Delete from  prd.ManuProductTypePro
	Where
	(PrdID=@PrdID)
END


/*
数据表 [prd.ManuProductTypePro]  按选择条件查询
*/
--=====================================================================

CREATE PROCEDURE prd.GetDataManuProductTypeProByPrdID
(
	@PrdID int   
)
AS
BEGIN
	SELECT 
		ProType1,
		ProType2,
		ProType3,
		ProType4,
		ProType5,
		ProType6,
		ProType7
	FROM prd.ManuProductTypePro
	WHERE 
		(PrdID=@PrdID)
	ORDER BY
		PrdID ASC
END


-----------------
-----------------
-- DROP table prd.ManuProductTypeProTable
create table prd.ManuProductTypeProTable(
	Fid int IDENTITY(1,1) NOT NULL,
	FFieldName varchar(100) ,
	FType varchar(100) ,
	FFieldType varchar(100) ,
	FFieldText varchar(100) ,
	FTypeParentID varchar(100) 
)ON [PRIMARY] 
GO 
/**
DELETE FROM  prd.ManuProductTypeProTable
insert into prd.ManuProductTypeProTable values('PrdID','0', 'int', '产品编码','')
insert into prd.ManuProductTypeProTable values('ProType1','1', 'int', '刀片R角','71')
insert into prd.ManuProductTypeProTable values('ProType2','1', 'int', '刀片左右手','114')
insert into prd.ManuProductTypeProTable values('ProType3','1', 'int', '排屑槽','73')
insert into prd.ManuProductTypeProTable values('ProType4','1', 'int', '被加工材料/刀片材质','72')
insert into prd.ManuProductTypeProTable values('ProType5','0', 'int', '','')
insert into prd.ManuProductTypeProTable values('ProType6','0', 'int', '','')
insert into prd.ManuProductTypeProTable values('ProType7','0', 'int', '','')
**/

/*
数据表 [prd.ManuProductTypeProTable]  按选择条件查询
*/
--=====================================================================
-- DROP PROCEDURE prd.GetDataManuProductTypeProTable
CREATE PROCEDURE prd.GetDataManuProductTypeProTable
AS
BEGIN
	SELECT 
		Fid,
		FFieldName,
		FType,
		FFieldType,
		FFieldText,
		FTypeParentID
	FROM prd.ManuProductTypeProTable
END



/*
数据表 [prd.ManuPrdType]  按选择条件查询
*/
--=====================================================================

CREATE PROCEDURE prd.GetDataManuPrdTypeByManuPrdTypeNameAndParentID
(
	@ManuPrdTypeName varchar (50)  ,
	@ParentID int   
)
AS
BEGIN
	SELECT 
		ManuPrdTypeID,
		ManuPrdTypeCode,
		ManuPrdTypeName,
		ParentID
	FROM prd.ManuPrdType
	WHERE 
		(ManuPrdTypeName=@ManuPrdTypeName) and 
		(ParentID=@ParentID)
END


/*
数据表 [prd.ManuPrdType]  按选择条件查询
*/
--=====================================================================

CREATE PROCEDURE prd.GetDataManuPrdTypeByParentID
(
	@ParentID int   
)
AS
BEGIN
	SELECT 
		*
	FROM prd.ManuPrdType
	WHERE 
		(ParentID=@ParentID)
END




--=====================================================================
--作者:金优富
--时间:2013-9-21 17:06:46
--描述
/*
数据表 [prd.Product]  按选择条件查询
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataAllManuProductByPrdTypeID]
CREATE PROCEDURE [prd].[GetDataAllManuProductByPrdTypeID]
(
	@PrdTypeID int
)
AS
BEGIN
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.ManuProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where PrdTypeID =@PrdTypeID
	union all
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.ManuProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where  PrdTypeID in (select PrdIDDesc from prd.ManuProductTypeProRelation where PrdIDSrc =  @PrdTypeID)
	 
END

GO

