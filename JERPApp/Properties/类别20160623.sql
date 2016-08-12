----------------------------------------------------------------------------------------------�����
----------------------------------------------------------------------------------------------�����
 -------- ��������------------
USE [XMHOnlineSolution]
GO

/****** Object:  Table [prd].[PrdType]    Script Date: 06/23/2016 10:49:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
---   drop table prd.[ComPrdType] select * from prd.ComPrdType
CREATE TABLE [prd].[ComPrdType](
	[PrdTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PrdTypeCode] [varchar](50) NOT NULL,
	[PrdTypeName] [varchar](50) NOT NULL,
	[Type] [int]  NOT NULL default(0),
	[ParentID] [int] NOT NULL,
	[RootID] [int] NOT NULL default(0),
 CONSTRAINT [PK_PrdTypeID] PRIMARY KEY CLUSTERED 
(
	[PrdTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_PADDING OFF
GO
ALTER TABLE [prd].[ComPrdType] ADD  CONSTRAINT [DF_ComPrdType_ParentID]  DEFAULT ((0)) FOR [ParentID]
ALTER TABLE [prd].[ComPrdType] ADD  CONSTRAINT [DF_ComPrdType_RootID]  DEFAULT ((0)) FOR [RootID]
ALTER TABLE [prd].[ComPrdType] ADD  CONSTRAINT [DF_ComPrdType_Type]  DEFAULT ((0)) FOR [Type]
GO
 -------- ��������------------
--- ɾ��Լ�� ALTER TABLE [prd].ManuPrdType Drop CONSTRAINT DF_ManuPrdType_Type
 
 /*
���ݱ� [prd.PrdType]  ��ѡ��������ѯ
*/
--=====================================================================
--- drop PROCEDURE [prd].[GetDataComPrdTypeByType] 
CREATE PROCEDURE [prd].[GetDataComPrdTypeByType]
	@Type int
AS
BEGIN
	SELECT 
		PrdTypeID,PrdTypeCode,PrdTypeName,ParentID,RootID,Type
	FROM prd.ComPrdType where Type = @Type
END

GO


--- drop PROCEDURE [prd].[GetDataComPrdTypeAll]
CREATE PROCEDURE [prd].[GetDataComPrdTypeAll]
AS
BEGIN
	SELECT 
		PrdTypeID,PrdTypeCode,PrdTypeName,ParentID,RootID,Type
	FROM prd.ComPrdType 
END

GO

/*
���ݱ� [prd.PrdTypes]  ɾ��
*/
--=====================================================================
--- drop PROCEDURE [prd].[DeleteComPrdType]
CREATE PROCEDURE [prd].[DeleteComPrdType]
(
	@PrdTypeID int   
)
AS
BEGIN
	Delete from  prd.ComPrdType
	Where
	(PrdTypeID=@PrdTypeID)
	exec prd.PM_DelChildComPrdType @PrdTypeID
END


GO



--- drop PROCEDURE [prd].[GetDataComPrdTypeDPType]
--- ��ȡ���ӽ׵ĵ�Ƭ���
CREATE PROCEDURE [prd].[GetDataComPrdTypeDPType]
AS
BEGIN
	SELECT 
		PrdTypeID,PrdTypeCode,PrdTypeName,ParentID,RootID,Type
	FROM prd.ComPrdType a where Type =2 
	and  not exists(select 1 FROM  prd.ComPrdType where Type =2 and ParentID = a.PrdTypeID  )
END

GO


--******************************************************************
--����:���Ÿ�
--ʱ��:2006-7-28
--����
/*
�ݹ�ɾ��֮ģ��
*/
--******************************************************************
-- drop  PROCEDURE [prd].[PM_DelChildGDPrdType]
CREATE  PROCEDURE [prd].[PM_DelChildComPrdType]
(
	@ParentID  bigint
)
AS
declare @child_ids varchar(1000) --��module_ID�б�
set @child_ids =''
declare @tmp_code varchar(50)
declare @tmp_id int
declare @i int
set @i=0
select @child_ids=@child_ids+ cast(PrdTypeID as varchar(32))+ ',' from PrdType where ParentID=@ParentID
while(len(@child_ids)>1)
begin
     set @i=charindex(',',@child_ids,0)
     if(@i>1)
     begin
        set @tmp_code=substring(@child_ids,1,@i-1)
        set @child_ids=stuff(@child_ids,1,@i,'')
        set @tmp_id=cast(@tmp_code as int)
        delete from PrdType where PrdTypeID=@tmp_id
        exec  prd.PM_DelChildPrdType @tmp_id
     end 
end

GO

/*
���ݱ� [prd.DGPrdType]  ����
*/
--=====================================================================
-- drop PROCEDURE [prd].[UpdateDGPrdType]
CREATE PROCEDURE [prd].[UpdateComPrdType]
(
	@PrdTypeID int   , 
	@PrdTypeCode varchar (50),
	@PrdTypeName varchar (50),
	@ParentID int
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ComPrdType
	SET 
		PrdTypeCode=@PrdTypeCode,
		PrdTypeName=@PrdTypeName,
		ParentID=@ParentID
	Where  PrdTypeID=@PrdTypeID
END

GO
---select * from prd.DGPrdType
/*
���ݱ� [prd.PrdType]  ���
*/
--=====================================================================
-- drop PROCEDURE [prd].[InsertComPrdType]
CREATE PROCEDURE [prd].[InsertComPrdType]
(
	@PrdTypeID int   out, 
	@PrdTypeCode varchar (50)  ,
	@PrdTypeName varchar (50)  ,
	@ParentID int   ,
	@Type int   
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ComPrdType
	( 
		PrdTypeCode,
		PrdTypeName,
		ParentID,
		Type 
	)
	Values
	( 
		@PrdTypeCode,
		@PrdTypeName,
		@ParentID,
		@Type
	)
	Set @PrdTypeID=SCOPE_IDENTITY()--���ر�ʶֵ
END

GO

/*
���ݱ� [prd.PrdType]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataComPrdTypeByParentID]
Create PROCEDURE prd.GetDataComPrdTypeByParentID
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


-- drop PROCEDURE [prd].[GetDataDGPrdTypeByParentID]
Create PROCEDURE prd.GetDataComPrdTypeByParentIDType
(
	@ParentID int,
	@Type  int
)
AS
BEGIN
	SELECT 
		*
	FROM prd.ComPrdType
	WHERE 
		(ParentID=@ParentID) and (Type=@Type)
END
GO

----------------------------------------------------------------------------------------------�����
----------------------------------------------------------------------------------------------�����


----------------------------------------------------------------------------------------------�������Ͻ���
----------------------------------------------------------------------------------------------�������Ͻ���

USE [XMHOnlineSolution]
GO

/****** Object:  Table [prd].[DGProduct]    Script Date: 06/24/2016 17:05:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
---  drop TABLE [prd].[DGProduct]
---  select * from  [prd].[DGProduct]
CREATE TABLE [prd].[DGProduct](
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
	[DPType] [int] NULL,
	[JMPrice] [money] NULL,
	[PFPrice] [money] NULL,
	[HYPrice] [money] NULL,
	[LSPrice] [money] NULL,
	[CustomCode] [varchar](50) NULL,
	[Brand]  [varchar](50) NULL,
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
 CONSTRAINT [PK_DGProduct_3] PRIMARY KEY CLUSTERED 
(
	[PrdID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_RohsFlag]  DEFAULT ((0)) FOR [RohsFlag]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_RohsRequireFlag]  DEFAULT ((0)) FOR [RohsRequireFlag]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_SaleFlag]  DEFAULT ((0)) FOR [SaleFlag]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_PrdSetFlag]  DEFAULT ((0)) FOR [PrdSetFlag]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_SetPrdCount]  DEFAULT ((0)) FOR [PrdSetCount]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_FileCount]  DEFAULT ((0)) FOR [FileCount]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_ImgCount]  DEFAULT ((0)) FOR [ImgCount]
GO

ALTER TABLE [prd].[DGProduct] ADD  CONSTRAINT [DF_DGProduct_StopFlag]  DEFAULT ((0)) FOR [StopFlag]
GO




--=====================================================================
--����:���Ÿ�
--ʱ��:2013-9-21 17:05:16
--����
/*
���ݱ� [prd.Product]  ɾ��
*/
--=====================================================================
--   drop  PROCEDURE prd.DeleteDGProduct
Create PROCEDURE prd.DeleteDGProduct
(
	@PrdID int   
)
AS
BEGIN
	Delete from  prd.DGProduct
	Where
	(PrdID=@PrdID)	
END

GO



/*
���ݱ� [prd.Product]  ��ѡ�����ɷ�ҳ��ѯ
*/
--=====================================================================
---   drop PROCEDURE [prd].[GetDataDGProductPagesFreeSearch]
CREATE PROCEDURE [prd].[GetDataDGProductPagesFreeSearch]
(
	@PageIndex int ,
	@PageSize int,
	@RecordCount int  out,
	@WhereClause nvarchar(MAX)
)
AS
BEGIN
	declare @sql nvarchar(MAX)
	set @sql='select @RecordCount=count(*) from prd.DGProduct a where (1=1) '+@WhereClause
	exec sp_executesql @sql,N'@RecordCount int output',@RecordCount output
	Set @sql='Select 
			a.*,general.F_GetUnitUnitName(UnitID) as UnitName,
			prd.F_GetPrdTypePrdTypeName(PrdTypeID) as PrdTypeName 
		from  (  select *,ROW_NUMBER() OVER(ORDER BY PrdID ASC) AS RowNum From prd.DGProduct a  Where (1=1) '+@WhereClause+' ) a  WHERE  RowNum Between '+cast(((@PageIndex-1) *@PageSize+1) as varchar(32))+' and '+cast( (@PageIndex*@PageSize) as varchar(32))
	EXEC(@sql)
END

GO

/*
���ݱ� [prd.PrdType]  PrdTypeName��ֵ����
*/
--=====================================================================
-- drop FUNCTION prd.F_GetDGPrdTypePrdTypeName
CREATE FUNCTION prd.F_GetDGPrdTypePrdTypeName
(
	@PrdTypeID int 
)
RETURNS
varchar (50)
AS
BEGIN
	DECLARE @rut varchar (50)
	SELECT Top 1 @rut=PrdTypeName FROM  prd.ComPrdType WHERE  Type = 2 and PrdTypeID=@PrdTypeID
	RETURN @rut
END
GO



/*
���ݱ� [prd.Product]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataDGProduct]
CREATE PROCEDURE [prd].[GetDataDGProduct]
AS
BEGIN
	SELECT 
		*,
		general.F_GetUnitUnitName(UnitID) as UnitName,
		prd.F_GetDGPrdTypePrdTypeName(PrdTypeID) as PrdTypeName
	FROM prd.DGProduct 
END

GO


/*
���ݱ� [prd.Product]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataDGProductByPrdID]
CREATE PROCEDURE [prd].[GetDataDGProductByPrdID]
(
	@PrdID int
)
AS
BEGIN
	SELECT 
		*,
		general.F_GetUnitUnitName(UnitID) as UnitName, 
		[prd].[F_GetPrdTypeTreePrdTypeName](PrdTypeID) as PrdTypeName
	FROM prd.DGProduct 
	where PrdID=@PrdID 
END

GO


/*
���ݱ� [prd.DGPrdType]  PrdTypeName��ֵ����
*/
--=====================================================================
--  drop FUNCTION [prd].[F_GetComPrdTypeTreePrdTypeName]
CREATE FUNCTION [prd].F_GetComPrdTypeTreePrdTypeName
(
	@PrdTypeID int,
	@Type int
)
RETURNS
varchar (500)
AS
BEGIN
	DECLARE @PrdTypeName varchar (50);
	declare @ParentID int;
	SELECT  @PrdTypeName=PrdTypeName,@ParentID=ParentID FROM  prd.ComPrdType WHERE PrdTypeID=@PrdTypeID and Type = @Type
	if(@ParentID>0)
	begin
		return  [prd].[F_GetPrdTypeTreePrdTypeName](@ParentID)+'>'+@PrdTypeName
	end
	return @PrdTypeName

END
GO


/*
���ݱ� [prd.Product]  ������ѯ
*/
--=====================================================================
--  drop PROCEDURE prd.GetParmDGProductMaxPrdCode
CREATE PROCEDURE prd.GetParmDGProductMaxPrdCode
(
	@PrdName varchar (100)  ,
	@PrdCode varchar (100)   out
)
AS
BEGIN
	SELECT 
		@PrdCode=max(PrdCode)
	FROM prd.DGProduct
	WHERE 
		(PrdName=@PrdName)
	if(@PrdCode is null) set @PrdCode=N''
END

GO

/*
���ݱ� [prd.Product]  ����
*/
--=====================================================================
--- drop PROCEDURE [prd].[UpdateDGProductForImgCount]
CREATE PROCEDURE [prd].[UpdateDGProductForImgCount]
(
	@PrdID int   ,
	@ImgCount int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DGProduct
	SET
		ImgCount=@ImgCount
	Where  (PrdID=@PrdID) 
END



--=====================================================================
--����:���Ÿ�
--ʱ��:2013-9-21 17:06:46
--����
/*
���ݱ� [prd.Product]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataDGProductByPrdTypeID]
----- ����
CREATE PROCEDURE [prd].[GetDataDGProductByPrdTypeID]
(
	@PrdTypeID int
)
AS
BEGIN
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
		,a2.ProType8,a2.ProType9,a2.ProType10,a2.ProType11,a2.ProType12,a2.ProType13,a2.ProType14,a2.ProType15
	FROM prd.DGProduct a1 left join prd.DGProductPro a2 on a1.PrdID = a2.PrdID
	where PrdTypeID =@PrdTypeID 
END

GO

-- drop PROCEDURE [prd].[GetDataDGProductByPrdTypeID]
--��Ƭ
CREATE PROCEDURE [prd].[GetDataDPProductByPrdTypeID]
(
	@PrdTypeID int
)
AS
BEGIN
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.DGProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where PrdTypeID =@PrdTypeID 
END

GO

/*
���ݱ� [prd.DGProduct]  ��ѡ��������ѯ
*/
--=====================================================================
--  drop PROCEDURE [prd].[GetDataDGProductByAssistantCode]
CREATE PROCEDURE [prd].[GetDataDGProductByAssistantCode]
(
	@AssistantCode varchar(50)
)
AS
BEGIN
	SELECT 
		*, 
		general.F_GetUnitUnitName(UnitID) as UnitName
	FROM prd.DGProduct 
	where AssistantCode like '%'+@AssistantCode+'%'
END

GO

----------------

--=====================================================================
--����:���Ÿ�
--ʱ��:2014/3/17 8:24:18
--����
/*
���ݱ� [prd.Product]  ���
*/
--=====================================================================
--  drop PROCEDURE prd.InsertDGProduct
CREATE PROCEDURE prd.InsertDGProduct
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
	@DPType int   ,
	@JMPrice numeric(18,6),
	@PFPrice numeric(18,6),
	@HYPrice numeric(18,6),
	@LSPrice numeric(18,6),
	@CustomCode varchar (50) ,
	@Brand varchar (50)  ,
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
	INSERT prd.DGProduct
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
		DPType,
		JMPrice,
		PFPrice,
		HYPrice,
		LSPrice,
		CustomCode,
		Brand,
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
		@DPType,
		@JMPrice,
		@PFPrice,
		@HYPrice,
		@LSPrice,
		@CustomCode,
		@Brand,
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
	Set @PrdID=SCOPE_IDENTITY()--���ر�ʶֵ
END
GO




--=====================================================================
--����:���Ÿ�
--ʱ��:2014/3/16 22:04:09
--����
/*
���ݱ� [prd.Product]  ���
*/
--=====================================================================
--- drop  PROCEDURE prd.InsertDGProductForImport
CREATE PROCEDURE prd.InsertDGProductForImport
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
	@DPType int,
	@JMPrice numeric(18,6),
	@PFPrice numeric(18,6),
	@HYPrice numeric(18,6),
	@LSPrice numeric(18,6),	 
	@CustomCode varchar(50),
	@Brand  varchar(50),
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.DGProduct
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
		DPType,
		JMPrice,
		PFPrice,
		HYPrice,
		LSPrice,
		CustomCode,
		Brand,
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
		@DPType,
		@JMPrice,
		@PFPrice,
		@HYPrice,
		@LSPrice,
		@CustomCode,
		@Brand,
		@MinPackingQty, 
		@URL,
		@Memo,
		@CustomFlag,
		@StopFlag
	)
	Set @PrdID=SCOPE_IDENTITY()--���ر�ʶֵ
END

GO







--=====================================================================
--����:���Ÿ�
--ʱ��:2014/3/17 8:24:53
--����
/*
���ݱ� [prd.Product]  ����
*/
--=====================================================================
---  drop PROCEDURE prd.UpdateDGProduct
CREATE PROCEDURE prd.UpdateDGProduct
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
	@DPType  int ,
	@JMPrice numeric(18,6),
	@PFPrice numeric(18,6),
	@HYPrice numeric(18,6),
	@LSPrice numeric(18,6),	 
	@CustomCode varchar(50),
	@Brand  varchar(50),
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
	UPDATE prd.DGProduct
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
		DPType = @DPType,
		JMPrice=@JMPrice,
		PFPrice=@PFPrice, 
		HYPrice=@HYPrice,
		LSPrice=@LSPrice,
		CustomCode=@CustomCode,
		Brand= @Brand,
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

---- select * from prd.DGProduct

/*
���ݱ� [prd.DGProduct]  ����
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateDGProductForPrdTypeID
CREATE PROCEDURE prd.UpdateDGProductForPrdTypeID
(
	@PrdID int  , 
	@PrdTypeID int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DGProduct
	SET
		PrdTypeID=@PrdTypeID
	where PrdID=@PrdID
END
--- select * from prd.DGProduct


--=====================================================================
--����:���Ÿ�
--ʱ��:2014/3/16 22:04:58
--����
/*
���ݱ� [prd.Product]  ����
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateDGProductForImport
CREATE PROCEDURE prd.UpdateDGProductForImport
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
	@DPType int,	 
	@JMPrice numeric(18,6),
	@PFPrice numeric(18,6),
	@HYPrice numeric(18,6),
	@LSPrice numeric(18,6),	 
	@CustomCode varchar(50),
	@Brand  varchar(50), 
	@MinPackingQty numeric(18,4), 
	@URL varchar(500),
	@Memo varchar(500),
	@CustomFlag bit,
	@StopFlag bit
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DGProduct
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
		DPType=@DPType,
		JMPrice=@JMPrice,
		PFPrice=@PFPrice, 
		HYPrice=@HYPrice,
		LSPrice=@LSPrice,
		CustomCode=@CustomCode,
		Brand = @Brand,
		MinPackingQty=@MinPackingQty, 
		URL=@URL,
		Memo=@Memo,
		CustomFlag=@CustomFlag,
		StopFlag=@StopFlag
	Where  (PrdID=@PrdID) 
END 

GO


/*
���ݱ� [prd.InsertDGProductForPrdSet]  ���
*/
--=====================================================================
-- drop PROCEDURE prd.InsertDProductForPrdSet
CREATE PROCEDURE prd.InsertDGProductForPrdSet
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
	INSERT prd.DGProduct
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
	Set @PrdID=SCOPE_IDENTITY()--���ر�ʶֵ
END

GO


/*
���ݱ� [prd.Product]  ����
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateDGProductForPrdSet
CREATE PROCEDURE prd.UpdateDGProductForPrdSet
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
	UPDATE prd.DGProduct
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

---------------------------------------------------------------------------------------------�������Ͻ���
---------------------------------------------------------------------------------------------�������Ͻ���
--------

/*
���͹�ϵ��
*/
-- drop TABLE [prd].[DGProductTypeProRelation]
CREATE TABLE [prd].[DGDPProductTypeProRelation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrdIDSrc] [int]  default(-1),
	[PrdIDDesc] [int]  default(-1)
)ON [PRIMARY] 
---- ��ز���
--����
���ݱ� [prd.DGDPProductTypeProRelation]  ���
*/
--=====================================================================
 -- drop  PROCEDURE prd.InsertDGDPProductTypeProRelation
CREATE PROCEDURE prd.InsertDGDPProductTypeProRelation
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
	Set @ID=SCOPE_IDENTITY()--���ر�ʶֵ
END

/*
���ݱ� [prd.ManuProductTypeProRelation]  ɾ��
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
���ݱ� [prd.ManuProductTypeProRelation]  ��ѡ��������ѯ
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
������������
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
���ݱ� [prd.ManuProductTypePro]  ���
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
���ݱ� [prd.ManuProductTypePro]  ����
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
���ݱ� [prd.ManuProductTypePro]  ɾ��
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
���ݱ� [prd.ManuProductTypePro]  ��ѡ��������ѯ
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
insert into prd.ManuProductTypeProTable values('PrdID','0', 'int', '��Ʒ����','')
insert into prd.ManuProductTypeProTable values('ProType1','1', 'int', '��ƬR��','71')
insert into prd.ManuProductTypeProTable values('ProType2','1', 'int', '��Ƭ������','114')
insert into prd.ManuProductTypeProTable values('ProType3','1', 'int', '��м��','73')
insert into prd.ManuProductTypeProTable values('ProType4','1', 'int', '���ӹ�����/��Ƭ����','72')
insert into prd.ManuProductTypeProTable values('ProType5','0', 'int', '','')
insert into prd.ManuProductTypeProTable values('ProType6','0', 'int', '','')
insert into prd.ManuProductTypeProTable values('ProType7','0', 'int', '','')
**/

/*
���ݱ� [prd.ManuProductTypeProTable]  ��ѡ��������ѯ
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
���ݱ� [prd.ManuPrdType]  ��ѡ��������ѯ
*/
--=====================================================================
---- drop PROCEDURE prd.GetDataComPrdTypeByManuPrdTypeNameAndParentID
CREATE PROCEDURE prd.GetDataComPrdTypeByManuPrdTypeNameAndParentID
(
	@PrdTypeName varchar (50)  ,
	@ParentID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		ParentID
	FROM prd.ComPrdType
	WHERE 
		Type = 1 and
		(PrdTypeName=@PrdTypeName) and 
		(ParentID=@ParentID)
END


/*
���ݱ� [prd.ManuPrdType]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE prd.GetDataComPrdTypeByParentID
CREATE PROCEDURE prd.GetDataComPrdTypeByParentID
(
	@ParentID int   
)
AS
BEGIN
	SELECT 
		*
	FROM prd.ComPrdType
	WHERE 
		(ParentID=@ParentID)
END




--=====================================================================
--����:���Ÿ�
--ʱ��:2013-9-21 17:06:46
--����
/*
���ݱ� [prd.Product]  ��ѡ��������ѯ
*/
--=====================================================================
-- drop PROCEDURE [prd].[GetDataAllDGDPProductByPrdTypeID]
CREATE PROCEDURE [prd].[GetDataAllDGDPProductByPrdTypeID]
(
	@PrdTypeID int
)
AS
BEGIN
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.DGProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where PrdTypeID =@PrdTypeID
	union all
	SELECT 
		a1.*, 
		general.F_GetUnitUnitName(UnitID) as UnitName,a2.ProType1,a2.ProType2,a2.ProType3,a2.ProType4,a2.ProType5,a2.ProType6,a2.ProType7
	FROM prd.DGProduct a1 left join prd.ManuProductTypePro a2 on a1.PrdID = a2.PrdID
	where  PrdTypeID in (select distinct DPType from prd.DGProduct where DPType is not null and PrdTypeID =@PrdTypeID)
END

GO




-----------------------------------------------------------------------------------��Ƭ���������
-----------------------------------------------------------------------------------
CREATE TABLE [prd].[DPPrdTypePro](
	[PrdTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PrdTypeCode] [varchar](50) NOT NULL,
	[PrdTypeName] [varchar](50) NOT NULL,
	[Type] [int]  NOT NULL default(0),
	[ParentID] [int] NOT NULL,
	[RootID] [int] NOT NULL default(0),
 CONSTRAINT [PK_PrdTypeProID] PRIMARY KEY CLUSTERED 
(
	[PrdTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [prd].[DPPrdTypePro] ADD  CONSTRAINT [DF_DPPrdTypePro_ParentID]  DEFAULT ((0)) FOR [ParentID]
ALTER TABLE [prd].[DPPrdTypePro] ADD  CONSTRAINT [DF_DPPrdTypePro_RootID]  DEFAULT ((0)) FOR [RootID]
ALTER TABLE [prd].[DPPrdTypePro] ADD  CONSTRAINT [DF_DPPrdTypePro_Type]  DEFAULT ((0)) FOR [Type]
GO


/*
���ݱ� [prd.DPPrdTypePro]  ���
*/
--=====================================================================
-- drop PROCEDURE prd.InsertDPPrdTypePro
CREATE PROCEDURE prd.InsertDPPrdTypePro
(
	@PrdTypeID int   out,
	@PrdTypeCode varchar (50)  ,
	@PrdTypeName varchar (50)  ,
	@Type int   ,
	@ParentID int   ,
	@RootID int   
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.DPPrdTypePro
	(
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	)
	Values
	(
		@PrdTypeCode,
		@PrdTypeName,
		@Type,
		@ParentID,
		@RootID
	)
	Set @PrdTypeID=SCOPE_IDENTITY()--���ر�ʶֵ
END


/*
���ݱ� [prd.DPPrdTypePro]  ����
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateDPPrdTypePro

CREATE PROCEDURE prd.UpdateDPPrdTypePro
(
	@PrdTypeID int   ,
	@PrdTypeCode varchar (50)  ,
	@PrdTypeName varchar (50)  
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DPPrdTypePro
	SET
		PrdTypeCode=@PrdTypeCode,
		PrdTypeName=@PrdTypeName
	Where  (PrdTypeID=@PrdTypeID) 
END


/*
���ݱ� [prd.DPPrdTypePro]  ����
*/
--=====================================================================

CREATE PROCEDURE prd.UpdateDPPrdTypeProForParentID
(
	@ParentID int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DPPrdTypePro
	SET
		ParentID=@ParentID
END

/*
���ݱ� [prd.DPPrdTypePro]  ɾ��
*/
--=====================================================================

CREATE PROCEDURE prd.DeleteDPPrdTypePro
(
	@PrdTypeID int   
)
AS
BEGIN
	Delete from  prd.DPPrdTypePro
	Where
	(PrdTypeID=@PrdTypeID)
END

/*
���ݱ� [prd.DPPrdTypePro]  ��ѡ��������ѯ
*/
--=====================================================================
---  drop PROCEDURE prd.GetDataDPPrdTypeProByPrdTypeID
CREATE PROCEDURE prd.GetDataDPPrdTypeProByPrdTypeID
(
	@PrdTypeID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.DPPrdTypePro
	WHERE 
		(PrdTypeID=@PrdTypeID)
END

/*
���ݱ� [prd.DPPrdTypePro]  ��ѡ��������ѯ
*/
--=====================================================================
CREATE PROCEDURE prd.GetDataDPPrdTypeProByParentID
(
	@ParentID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.DPPrdTypePro
	WHERE 
		(ParentID=@ParentID)
END

-- drop PROCEDURE prd.GetDataDPPrdTypePro
CREATE PROCEDURE prd.GetDataDPPrdTypePro
(
	@PrdTypeID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.DPPrdTypePro
END


-- drop PROCEDURE prd.GetDataDPPrdTypeProByType
CREATE PROCEDURE prd.GetDataDPPrdTypeProByType
(
	@Type int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.DPPrdTypePro
	where (Type=@Type)
END



-----------------------------------------------------------------------------------ͨ�����������
-----------------------------------------------------------------------------------
CREATE TABLE [prd].[ComTypePro](
	[PrdTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PrdTypeCode] [varchar](50) NOT NULL,
	[PrdTypeName] [varchar](50) NOT NULL,
	[Type] [int]  NOT NULL default(0),
	[ParentID] [int] NOT NULL,
	[RootID] [int] NOT NULL default(0),
 CONSTRAINT [PK_ComTypePro] PRIMARY KEY CLUSTERED 
(
	[PrdTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [prd].[ComTypePro] ADD  CONSTRAINT [DF_ComTypePro_ParentID]  DEFAULT ((0)) FOR [ParentID]
ALTER TABLE [prd].[ComTypePro] ADD  CONSTRAINT [DF_ComTypePro_RootID]  DEFAULT ((0)) FOR [RootID]
ALTER TABLE [prd].[ComTypePro] ADD  CONSTRAINT [DF_ComTypePro_Type]  DEFAULT ((0)) FOR [Type]
GO


/*
���ݱ� [prd.ComTypePro]  ���
*/
--=====================================================================
-- drop PROCEDURE prd.InsertComTypePro
CREATE PROCEDURE prd.InsertComTypePro
(
	@PrdTypeID int   out,
	@PrdTypeCode varchar (50)  ,
	@PrdTypeName varchar (50)  ,
	@Type int   ,
	@ParentID int   ,
	@RootID int   
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.ComTypePro
	(
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	)
	Values
	(
		@PrdTypeCode,
		@PrdTypeName,
		@Type,
		@ParentID,
		@RootID
	)
	Set @PrdTypeID=SCOPE_IDENTITY()--���ر�ʶֵ
END


/*
���ݱ� [prd.ComTypePro]  ����
*/
--=====================================================================
-- drop PROCEDURE prd.UpdateComTypePro

CREATE PROCEDURE prd.UpdateComTypePro
(
	@PrdTypeID int   ,
	@PrdTypeCode varchar (50)  ,
	@PrdTypeName varchar (50)  
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ComTypePro
	SET
		PrdTypeCode=@PrdTypeCode,
		PrdTypeName=@PrdTypeName
	Where  (PrdTypeID=@PrdTypeID) 
END


/*
���ݱ� [prd.ComTypePro]  ����
*/
--=====================================================================

CREATE PROCEDURE prd.UpdateComTypeProForParentID
(
	@ParentID int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.ComTypePro
	SET
		ParentID=@ParentID
END

/*
���ݱ� [prd.ComTypePro]  ɾ��
*/
--=====================================================================

CREATE PROCEDURE prd.DeleteComTypePro
(
	@PrdTypeID int   
)
AS
BEGIN
	Delete from  prd.ComTypePro
	Where
	(PrdTypeID=@PrdTypeID)
END

/*
���ݱ� [prd.ComTypePro]  ��ѡ��������ѯ
*/
--=====================================================================
---  drop PROCEDURE prd.GetDataComTypeProByPrdTypeID
CREATE PROCEDURE prd.GetDataComTypeProByPrdTypeID
(
	@PrdTypeID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.ComTypePro
	WHERE 
		(PrdTypeID=@PrdTypeID)
END

/*
���ݱ� [prd.ComTypePro]  ��ѡ��������ѯ
*/
--=====================================================================
CREATE PROCEDURE prd.GetDataComTypeProByParentID
(
	@ParentID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.ComTypePro
	WHERE 
		(ParentID=@ParentID)
END

-- drop PROCEDURE prd.GetDataComTypePro
CREATE PROCEDURE prd.GetDataComTypePro
(
	@PrdTypeID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.ComTypePro
END


-- drop PROCEDURE prd.GetDataComTypeProByType
CREATE PROCEDURE prd.GetDataComTypeProByType
(
	@Type int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.ComTypePro
	where (Type=@Type)
END

--------------------------------------------�Զ�����������
--------------------------------------------
create table prd.OtherProductPro(
	Fid int IDENTITY(1,1) NOT NULL,
	FFieldName varchar(100) , --�ֶ�����
	Fvisable varchar(100) ,   --�Ƿ�ɼ�
	FType  int null,          --���ͣ����ࣩ 
	FFieldType varchar(100) , --�ֶ�����
	FFieldText varchar(100) , --����
	FTypeSrcID varchar(100), --ȡ��
	FSrcTable varchar(100)
)ON [PRIMARY] 
GO 

/**
insert into prd.OtherProductPro values('PrdID','0','10','int', 'PrdID','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType1','1','10','int', '����1','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType2','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType3','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType4','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType5','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType6','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType7','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType8','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType9','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType10','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType11','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType12','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType13','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType14','0','10','int', '����2','0','prd.DGProductPro')
insert into prd.OtherProductPro values('ProType15','0','10','int', '����2','0','prd.DGProductPro')
**/


--- ��ѯ
CREATE PROCEDURE prd.GetDataOtherProductProByFType
(
	@FType int   
)
AS
BEGIN
	SELECT 
		Fid,
		FFieldName,
		Fvisable,
		FType,
		FFieldType,
		FFieldText,
		FTypeSrcID,
		FSrcTable
	FROM prd.OtherProductPro
	WHERE 
		(FType=@FType)
END

------- ����
--=====================================================================

CREATE PROCEDURE prd.InsertOtherProductPro
(
	@Fid int   out,
	@FFieldName varchar (100)  ,
	@Fvisable varchar (100)  ,
	@FType int   ,
	@FFieldType varchar (100)  ,
	@FFieldText varchar (100)  ,
	@FTypeSrcID varchar (100)  ,
	@FSrcTable varchar (100)  
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT prd.OtherProductPro
	(
		FFieldName,
		Fvisable,
		FType,
		FFieldType,
		FFieldText,
		FTypeSrcID,
		FSrcTable
	)
	Values
	(
		@FFieldName,
		@Fvisable,
		@FType,
		@FFieldType,
		@FFieldText,
		@FTypeSrcID,
		@FSrcTable
	)
	Set @Fid=SCOPE_IDENTITY()--���ر�ʶֵ
END

/*
���ݱ� [prd.OtherProductPro]  ɾ��
*/
--=====================================================================

CREATE PROCEDURE prd.DeleteOtherProductPro
(
	@Fid int   
)
AS
BEGIN
	Delete from  prd.OtherProductPro
	Where
	(Fid=@Fid)
END

================== �����������Ա�
CREATE TABLE [prd].[DGProductPro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrdID] int default(-1),
	[ProType1] int default(-1),
	[ProType2] int  default(-1),
	[ProType3] int  default(-1),
	[ProType4] int  default(-1),
	[ProType5] int  default(-1),
	[ProType6] int  default(-1),
	[ProType7] int  default(-1),
	[ProType8] int  default(-1),
	[ProType9] int  default(-1),
	[ProType10] int  default(-1),
	[ProType11] int  default(-1),
	[ProType12] int  default(-1),
	[ProType13] int  default(-1),
	[ProType14] int  default(-1),
	[ProType15] int  default(-1)
		CONSTRAINT [PK_DGProductPro_PrdID] PRIMARY KEY CLUSTERED 
	(
	[PrdID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO
/*
���ݱ� [prd.DGProductPro]  ��ѡ��������ѯ
*/
--=====================================================================
CREATE PROCEDURE prd.GetDataDGProductProByPrdID
(										
	@PrdID int   
)
AS
BEGIN
	SELECT 
		ID,
		PrdID,
		ProType1,
		ProType2,
		ProType3,
		ProType4,
		ProType5,
		ProType6,
		ProType7,
		ProType8,
		ProType9,
		ProType10,
		ProType11,
		ProType12,
		ProType13,
		ProType14,
		ProType15
	FROM prd.DGProductPro
	WHERE 
		(PrdID=@PrdID)
END


/*
���ݱ� [prd.DGProductPro]  ���
*/
--=====================================================================
-- drop PROCEDURE prd.InsertDGProductPro
CREATE PROCEDURE prd.InsertDGProductPro
(
	@ID int   out,
	@PrdID int   ,
	@ProType1 int   ,
	@ProType2 int   ,
	@ProType3 int   ,
	@ProType4 int   ,
	@ProType5 int   ,
	@ProType6 int   ,
	@ProType7 int   ,
	@ProType8 int   ,
	@ProType9 int   ,
	@ProType10 int   ,
	@ProType11 int   ,
	@ProType12 int   ,
	@ProType13 int   ,
	@ProType14 int   ,
	@ProType15 int   
)
AS
BEGIN
	SET NOCOUNT ON
	declare @prd_id bigint
	select @prd_id = PrdID from prd.DGProductPro where PrdID = @PrdID;
	if (@prd_id > 0)
		BEGIN
			EXEC prd.UpdateDGProductPro @PrdID ,@ProType1,@ProType2,@ProType3,@ProType4,@ProType5,@ProType6,@ProType7
			,@ProType8,@ProType9,@ProType10,@ProType11,@ProType12,@ProType13,@ProType14,@ProType15
		END
	ELSE
	INSERT prd.DGProductPro
	(
		PrdID,
		ProType1,
		ProType2,
		ProType3,
		ProType4,
		ProType5,
		ProType6,
		ProType7,
		ProType8,
		ProType9,
		ProType10,
		ProType11,
		ProType12,
		ProType13,
		ProType14,
		ProType15
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
		@ProType7,
		@ProType8,
		@ProType9,
		@ProType10,
		@ProType11,
		@ProType12,
		@ProType13,
		@ProType14,
		@ProType15
	)
	Set @ID=SCOPE_IDENTITY()--���ر�ʶֵ
END

/*
���ݱ� [prd.DGProductPro]  ����
*/
--=====================================================================
-- drop  PROCEDURE prd.UpdateDGProductPro
CREATE PROCEDURE prd.UpdateDGProductPro
(
	@PrdID int   ,
	@ProType1 int   ,
	@ProType2 int   ,
	@ProType3 int   ,
	@ProType4 int   ,
	@ProType5 int   ,
	@ProType6 int   ,
	@ProType7 int   ,
	@ProType8 int   ,
	@ProType9 int   ,
	@ProType10 int   ,
	@ProType11 int   ,
	@ProType12 int   ,
	@ProType13 int   ,
	@ProType14 int   ,
	@ProType15 int   
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE prd.DGProductPro
	SET
		ProType1=@ProType1,
		ProType2=@ProType2,
		ProType3=@ProType3,
		ProType4=@ProType4,
		ProType5=@ProType5,
		ProType6=@ProType6,
		ProType7=@ProType7,
		ProType8=@ProType8,
		ProType9=@ProType9,
		ProType10=@ProType10,
		ProType11=@ProType11,
		ProType12=@ProType12,
		ProType13=@ProType13,
		ProType14=@ProType14,
		ProType15=@ProType15
	Where  (PrdID=@PrdID) 
END

/*
���ݱ� [prd.DGProductPro]  ɾ��
*/
--=====================================================================

CREATE PROCEDURE prd.DeleteDGProductPro
(
	@PrdID int   
)
AS
BEGIN
	Delete from  prd.DGProductPro
	Where
	(PrdID=@PrdID)
END



/*
���ݱ� [prd.Product]  �������Ƽ������Ҳ�Ʒ����
*/
--=====================================================================
--- drop PROCEDURE prd.GetDataProductByPrdTypeIDAndPrdName
CREATE PROCEDURE prd.GetDataProductByPrdTypeIDAndPrdName
(
	@PrdTypeID int   ,
	@PrdName varchar (100)  
)
AS
BEGIN
	SELECT 
		PrdID,
		PrdTypeID,
		PrdCode,
		PrdName,
		PrdSpec,
		Model,
		Surface
	FROM prd.Product
	WHERE 
		(PrdTypeID=@PrdTypeID) and 
		(PrdName=@PrdName)
END


/*
���ݱ� [prd.DPPrdTypePro]  ��Ƭ�������������ѯ
*/
--=====================================================================

CREATE PROCEDURE prd.GetDataDPPrdTypeProByPrdTypeNameAndParentID
(
	@PrdTypeName varchar (50)  ,
	@ParentID int   
)
AS
BEGIN
	SELECT 
		PrdTypeID,
		PrdTypeCode,
		PrdTypeName,
		Type,
		ParentID,
		RootID
	FROM prd.DPPrdTypePro
	WHERE 
		(PrdTypeName=@PrdTypeName) and 
		(ParentID=@ParentID)
END












select * from prd.DPPrdTypePro  ---��Ƭ����

select* from [prd].[ComPrdType] --��Ƭ�͵�������

select* from  [prd].[DGProduct]  --���˵�Ƭ��Ʒ��

select* from  [prd].[ManuProductTypePro]  -- ��Ƭ���Դ����

select * from prd.ManuProductTypeProTable  --- ��Ƭ���Կ��Ʊ�

---update prd.ManuProductTypeProTable set FFieldText='��Ƭ����',FTypeParentID =44,FType=1 where Fid=30
----update prd.ManuProductTypeProTable set FFieldText='���ӹ����ϲ���' where Fid=30
