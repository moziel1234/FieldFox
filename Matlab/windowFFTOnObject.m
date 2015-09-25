function [ output_args ] = windowFFTOnObject( meas_obj )
%WINDOWFFTONOBJECT Summary of this function goes here
%   Detailed explanation goes here
plotC=1;
if nargin==0
    t= 0.001:0.001:30;
    f1=80/60;
    f2=90/60;
    f3=70/60;
    amp(1:10000) = sin(2*pi*f1*t(1:10000));
    amp(10000:20000) = 0.8*sin(2*pi*f2*t(10000:20000));
    amp(20000:30000) = 0.6*sin(2*pi*f3*t(20000:30000));
end
window_size_sec = 3; %at seconds
window_size = find(t>=window_size_sec,1);
Fs = 1/(t(2)-t(1));

ind = 0;
for i=window_size+1:1:length(t)
    ind = ind + 1;
    res_time(ind) = t(i) - window_size_sec/2;
    temp_amp = amp(i-window_size:i);    
    L = length(temp_amp);
    NFFT = 2^nextpow2(L)*2; % Next power of 2 from length of y
    Y = fft(temp_amp,NFFT)/L;
    f = Fs/2*linspace(0,1,NFFT/2+1);
    spec = 2*abs(Y(1:NFFT/2+1));
    [~,max_ind] = max(spec);
    res_amp(ind) = f(max_ind)*60;
end
if plotC
    figure; plot(res_time,res_amp);
end
end

