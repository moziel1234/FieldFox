function [ output_args ] = crosscor( pulse_data, index_vec )
% The function will get as input a vector of pulses and vector of indexes
% that part the pulses and will apply cross corrlation over the samples.
% The function doesn't assuming uniform pulse durations and will interpulate them to a uniform one. 

max_ind = max(diff(index_vec));
res = zeros(1,max_ind);
ind = 0;
for i=2:length(index_vec)-1;
    first_sig = InterSig(pulse_data(index_vec(i-1):index_vec(i)),max_ind);    
    second_sig = InterSig(pulse_data(index_vec(i):index_vec(i+1)),max_ind);   
    temp = ifft(fft(first_sig).*conj(fft(second_sig)));
    res = res + temp;  
    if mod(ind,1) == 0
        template = fftshift(res);
        figure; plot(template);
    end
    ind = ind + 1;
end
template = fftshift(res);
figure; plot(template); title('Results after averaging');
end

function [Y_amp,f] = myfft(sig,t)
    dt = t(2)-t(1);
    Fs = 1/dt;
    L = length(sig);
    NFFT = 2^nextpow2(L)*2; % Next power of 2 from length of y
    f = Fs/2*linspace(0,1,NFFT/2+1);
    t_zeropadd = t(1):dt:t(1)+(NFFT-1)*dt;
    
    Y_amp = fft(sig,NFFT)/L;    
    spec_amp = 2*abs(Y_amp(1:NFFT/2+1));
    %figure; plot(t, sig); title('Orig signal');
    %figure; plot(f, spec_amp); title('Signal Freq domain');
    %figure; plot(t_zeropadd, (ifft(Y_amp*L))); title('Orig signal after ifft'); xlim([t(1),t(end)]);
end

function inter_sig = InterSig(data, sig_length)
    inter_sig = interp1(1:length(data), data, linspace(1,length(data),sig_length),'spline');
end



