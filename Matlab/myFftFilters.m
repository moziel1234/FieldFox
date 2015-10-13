function [ output_args ] = myFftFilters( obj )
%MYFFTFILTERS Summary of this function goes here
%   Detailed explanation goes here
    obj.amp_db = obj.amp_db(3000:4000);
    t_orig = obj.time_sec(3000:4000);    
    t = linspace(0,t_orig(end)-t_orig(1),length(t_orig)*length(obj.freqs));
    Fs = 1/(t(2)-t(1));
    L = length(obj.amp_db);
    NFFT = 2^nextpow2(L)*2; % Next power of 2 from length of y
    f = Fs/2*linspace(0,1,NFFT/2+1);
    
    Y_amp = fft(obj.amp_db,NFFT)/L;    
    spec_amp = 2*abs(Y_amp(1:NFFT/2+1));
    figure; plot(obj.amp_db);
    figure; plot(f,spec_amp);

end

