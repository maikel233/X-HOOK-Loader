<?php

include("connect.php");

$username = mysql_escape_string($_GET['username']);
$password = mysql_escape_string($_GET['password']);
$HWID = mysql_escape_string($_GET['HWID']);

$squery = mysql_query("SELECT * FROM users WHERE username='$username'");
$query = mysql_fetch_array($squery);
$rowcount = mysql_num_rows($squery);


if($rowcount == 1)
{
	
	if($password != $query['password'])
	{
		echo'Password incorrect!';
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
				
				$sql = "UPDATE user SET username = '$username', password = '$password', hwid = '$HWID' WHERE id = $rowcount";
				mysql_query($sql);
				echo'Inserted';
			}
			else
			{
				if($HWID != $query['hwid'])
				{
					echo'An other computer is activated with this account!';
				}
				else
				{
					echo'we cant do shit!';
				}
					
			}	
		
		}	
		
	}	
	
}

else
	echo 'Username does not exist!';

?>






