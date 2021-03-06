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
    amp = amp';
    phs = amp;
    freqs = [(f1+f2+f3)/3];
else
    t_orig = meas_obj.time_sec;
    amp_orig = meas_obj.amp_db;
    phs_orig = meas_obj.phase_deg;
    freqs = meas_obj.freqs;
    t = linspace(0,t_orig(end)-t_orig(1),length(t_orig)*length(freqs));
    amp = [];
    phs = [];
    for i=1:1:length(amp_orig(:,1))
        amp = [amp , amp_orig(i,:)];
        phs = [phs , phs_orig(i,:)];
    end
end
%amp = smooth(amp,30);
window_size_sec = 17; %at seconds
window_size = find(t>=window_size_sec,1);
Fs = 1/(t(2)-t(1));

ind = 0;
disp('before loop');
for i=window_size+1:1:length(t)

    ind = ind + 1;
    res_time(ind) = t(i) - window_size_sec/2;
    temp_amp = amp(i-window_size:i);
    temp_phs = phs(i-window_size:i);
    L = length(temp_amp);
    NFFT = 2^nextpow2(L)*2; % Next power of 2 from length of y
    f = Fs/2*linspace(0,1,NFFT/2+1);
    
    Y_amp = fft(temp_amp,NFFT)/L;    
    spec_amp = 2*abs(Y_amp(1:NFFT/2+1));
    norm_spec_amp = spec_amp/max(spec_amp);
    res_amp(ind) = sum(norm_spec_amp(f<4));
    
    Y_phs = fft(temp_phs,NFFT)/L;    
    spec_phs = 2*abs(Y_phs(1:NFFT/2+1));
    norm_spec_phs = spec_phs/max(spec_phs);
    res_phs(ind) = sum(norm_spec_phs(f<4));
end
%res_amp = smooth(res_amp,40);
%res_phs = smooth(res_phs,40);

if plotC
    figure; plot(res_time,res_amp,'b'); %xlim([12.5,15.5]);
    figure; plot(res_time,smooth(res_phs),'r'); %xlim([12.5,15.5]);
end

end

