function [ output_args ] = pulseMeter(file_name)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here
close all;
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
figure; plot(time_full,smooth(smooth(amp,100),100));

end

