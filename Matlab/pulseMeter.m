function [ ret_obj ] = pulseMeter(file_name)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here
    plotC = 0;
    M = dlmread(file_name);
    time = M(:,1)-M(1,1);
    [m,n] = size(M);

    time_full = zeros((m-1)*(n-1),1);
    amp = time_full; 
    for i=2:1:m
        time_full(((i-2)*600)+1:(i-1)*600,1)=linspace(time(i-1),time(i),n-1);
        amp(((i-2)*600)+1:(i-1)*600,1)=M(i,2:n);
    end
    time_full = time_full/1000;

    % Find minimas
    smoothed_data = smooth(smooth(amp,100),100);
    DataInv = 1.01*max(smoothed_data) - smoothed_data;
    [~,MinIdx] = findpeaks(DataInv, 'MinPeakDistance',1200);

    if plotC
        figure; plot(time_full,smooth(smooth(amp,5),5),'b'); hold on; plot(time_full,smoothed_data,'g');
        scatter(time_full(MinIdx),smoothed_data(MinIdx),'r');
    end
    ret_obj.time_full = time_full;
    ret_obj.smoothed_data = smoothed_data;
    ret_obj.first_meas_epoch = M(1,1);
end

