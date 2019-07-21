/**BEGIN ******************************  测试表 ****************************************************/
USE TELDBASE;
GO

/*==============================================================*/
/* Table: Base_Shangxin				                   */
/* Description:测试表									    */
/* Author:shaocx												*/
/* CreateTime:2017-02-16								    */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS  WHERE ID = OBJECT_ID('Base_Shangxin') AND TYPE = 'U')
create table Base_Shangxin (
   ID                 char(36)         not  null, -- 内码

   Code       varchar(50)	 not null,-- 编号
   Name	      varchar(50)	 not null,-- 名称
   
   
   Creator		varchar(128)	null,-- 创建人
   CreateTime		datetime	null,-- 创建时间
   LastModifier		varchar(128)	null,-- 修改人
   LastModifyTime   datetime	null -- 修改时间
   
   constraint PK_Base_Shangxin primary key (ID)
)
GO

SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'LastModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO