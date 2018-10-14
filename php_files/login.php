<?php

include("connect.php");

$username = mysql_escape_string($_GET['username']);
//$password = mysql_escape_string($_GET['password']);
$HWID = mysql_escape_string($_GET['HWID']);
$TIME = mysql_escape_string($_GET['TIME']);
$squery = mysql_query("SELECT * FROM users WHERE username='$username'");
$query = mysql_fetch_array($squery);
$rowcount = mysql_num_rows($squery);

if($rowcount == 1)
{
	if($TIME > $query['activesubscription'])
			{				
			 echo 'No Active subscription.';
			}
		
		else
		{	
		if($query['activesubscription'] == '')
		{
			echo 'No Active subscription.';
		}
		
		else
		{
			
			if ($TIME == '')
			
			{
				echo 'No Active subscription.';
			}
			
			else
			{
	
		if($query['banned'] != '0')
		{
		  echo $query['reason'];
		}
		else			
			{
			if($query['hwid'] == '')
			{		
				mysql_query("UPDATE users SET hwid='$HWID' WHERE username='$username'");
			//	mysql_query("INSERT INTO users(username, hwid) VALUES ('$username', '$HWID')");
				echo'New Device activation!';
			}
			else	
			{
				if($HWID != $query['hwid'])
				{
					echo'An other computer is activated with this account!';
				}
				else
				{
					echo'we cant do shit!'; // The phrase means you are allowed to login...
				}
					
			}	
			}
		}
		}
		}
}

else
	echo 'Username does not exist!';

?>