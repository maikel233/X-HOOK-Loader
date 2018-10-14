<?
include("connect.php");


$detectionstatus = mysql_fetch_assoc(mysql_query("SELECT * FROM `detectionstatus` WHERE `id` = '1'  LIMIT 1"));
echo $detectionstatus['VAC'];
echo $detectionstatus['ESEA'];
echo $detectionstatus['FACEIT'];

?>