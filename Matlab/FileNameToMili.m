function ret_time = FileNameToMili(file_name)
    % 1045578098_0.s2p
    % hhmmssfff
    hours = str2double(file_name(1:2)) * 60 * 60 * 1000;
    minutes = str2double(file_name(3:4)) * 60 * 1000;
    seconds = str2double(file_name(5:6)) * 1000;
    mili = str2double(file_name(7:9));
    ret_time = hours + minutes + seconds + mili;
end