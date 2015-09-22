function [ ret_obj ] = folderToObject( folder_name )
%FOLDERTOOBJECT Summary of this function goes here
%   Detailed explanation goes here
    ret_obj = 0;
    D = dir([folder_name,'\*.s2p']);
    S = sort({D.name});
    ind = 0;
    times = zeros(size(S));
    for file_name = S
        ind = ind +1;
        times(ind) = FileNameToMili(file_name{1});
        data = read(rfdata.data,[folder_name,'\\',file_name{1}]);
        freqs = data.freq;
        if ind==1
            amp = zeros(length(S),length(data.freq));
            phase = zeros(length(S),length(data.freq));
        end
        amp
    end
    figure; plot(times-times(1));

end

function ret_time = FileNameToMili(file_name)
    % 1045578098_0.s2p
    % hhmmssfff
    hours = str2double(file_name(1:2)) * 60 * 60 * 1000;
    minutes = str2double(file_name(3:4)) * 60 * 1000;
    seconds = str2double(file_name(5:6)) * 1000;
    mili = str2double(file_name(7:9));
    ret_time = hours + minutes + seconds + mili;
end

