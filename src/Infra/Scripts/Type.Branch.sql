use DCV_PI
go


CREATE TYPE dbo.BranchTableType AS TABLE
(
    ReleaseId int,
    Branch varchar(max)
);
GO