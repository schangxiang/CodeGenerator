/**BEGIN ******************************  ���Ա� ****************************************************/
USE TELDBASE;
GO

/*==============================================================*/
/* Table: Base_Shangxin				                   */
/* Description:���Ա�									    */
/* Author:shaocx												*/
/* CreateTime:2017-02-16								    */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS  WHERE ID = OBJECT_ID('Base_Shangxin') AND TYPE = 'U')
create table Base_Shangxin (
   ID                 char(36)         not  null, -- ����

   Code       varchar(50)	 not null,-- ���
   Name	      varchar(50)	 not null,-- ����
   
   
   Creator		varchar(128)	null,-- ������
   CreateTime		datetime	null,-- ����ʱ��
   LastModifier		varchar(128)	null,-- �޸���
   LastModifyTime   datetime	null -- �޸�ʱ��
   
   constraint PK_Base_Shangxin primary key (ID)
)
GO

SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޸���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'LastModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޸�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Shangxin', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO