<?php

// This script needs to be in a folder under the unity project root
// e.g. unityprojectfolder\buildscripts\thisscript.php

// Need unity editor in PATH
$projectPath = dirname(getcwd());

//$unityEditorPath = 'Unity';
$buildPath = '"..\Build\Debug\Web Player\Current"';

exec("taskkill /im Unity.exe");
exec("sleep 1");
exec("Unity -batchmode -quit -buildWebPlayer " . $buildPath);
//system('start Unity -projectPath "' . $projectPath . '"');
echo "Finished!";
