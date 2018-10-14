<?php

include("connect.php");

$username = mysql_escape_string($_GET['username']);
$password = mysql_escape_string($_GET['password']);
$HWID = mysql_escape_string($_GET['HWID']);

$squery = mysql_query("SELECT * FROM users");
$query = mysql_fetch_array($squery);

if($HWID != $query['hwid'])
{
	if($username != $query['username'])
	{
		mysql_query("INSERT INTO users(username, password, hwid) VALUES ('$username', '$password', '$HWID')");
		echo'Inserted';
	}
	else
	{
		echo'Username already exist!';
	}
}
else
{
	echo 'HWID already in database!';
}


?>