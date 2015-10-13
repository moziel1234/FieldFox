function [ output_args ] = try_crosscor( input_args )
%TRY_CROSSCOR Summary of this function goes here
%   Detailed explanation goes here
close all;
t=[-10:0.1:10];
% z0= sinc(t);
% %myfft(z0,-10:0.1:10);
% z1 = [];
% for i=1:1:100
%   z1 = [z1,z0];
% end
z1 = [];
for i=1:1:500
    rand_param = 2*rand(1);
    z1 = [z1,sinc(-10+rand_param:0.1:10+rand_param)];
end
figure; plot(z1); xlim([0,1503]);
%a,b] = xcorr(z1,z0);
%figure; plot(b,a); title('xcorr before filter');
z11 = z1 + 4*rand(1,length(z1));
t_z11= 0:0.1:0.1*(length(z11)-1);
figure; plot(z11); xlim([0,1503]);
res = zeros(1,201);
for i=201:201:length(z11)-201;
    first_sig = z11(i-200:i);    
    second_sig = z11(i+1:i+201);    
    temp = ifft(fft(first_sig).*conj(fft(second_sig)));
    res = res + temp;   
end
template = fftshift(res);
figure; plot(template); title('Results after averaging');
temp_freqs = myfft(template,t);
abs_temp_freqs = abs(temp_freqs);
filtered_sig = [];
for i=1:1:length(z11)-201;
    sig = z11(i:i+200);    
    [freq_sig, f] = myfft(sig,t);
    abs_freq_sig = abs(freq_sig);
    %filtered_freqs = (abs_temp_freqs/max(abs_temp_freqs)).*(abs_freq_sig./max(abs_freq_sig));
    %res2(i) = sum(abs(filtered_freqs));
    res2(i) = std((abs_temp_freqs/max(abs_temp_freqs)),(abs_freq_sig./max(abs_freq_sig)));
    %res2(i) = sum(  ((abs_temp_freqs/max(abs_temp_freqs))-(abs_freq_sig./max(abs_freq_sig)))./(abs_temp_freqs/max(abs_temp_freqs)));
end
DataInv = 1.01*max(res2) - res2;
[Minima,MinIdx] = findpeaks((DataInv),'MinPeakDistance',180);
figure; plot((res2)); xlim([1,1503]);hold on; plot(MinIdx,res2(MinIdx),'g*');
figure; plot(z1);  hold on; plot(MinIdx,z1(MinIdx),'g*'); xlim([0,1503]); 
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



