CREATE PROCEDURE [dbo].[usp_GetAllBooksByPublisher]
	 
AS
begin
	SELECT * from Book bk order by bk.Publisher,bk.AuthorLastName,bk.AuthorFirstName,bk.Title
end
