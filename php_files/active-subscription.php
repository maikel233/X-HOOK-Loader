<?
include("connect.php");

$username = mysql_escape_string($_GET['username']);


$squery = mysql_query("SELECT * FROM users WHERE username='$username'");
$query = mysql_fetch_array($squery);
$rowcount = mysql_num_rows($squery);




if($rowcount == 1)
{
	if($query['activegames'] != '0')
		{
		  echo $query['activegames'];
		}
	else
	{
		echo'Something went wrong!';
	}
		
}
?>