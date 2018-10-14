<?php

$user = $_POST['user'];
$img = $_POST['img'];

$fp = fopen('data.txt', 'a');
fwrite($fp, "user: " . $user . " : " . "img: " . $img);
fclose($fp);
?>