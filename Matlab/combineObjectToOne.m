function [ flat_amp ,flat_phs, time] = combineObjectToOne(in_obj )
%COMBINEOBJECTTOONE Summary of this function goes here
%   Detailed explanation goes here
    in_obj.amp_db = in_obj.amp_db';
    in_obj.phase_deg = in_obj.phase_deg';
    plotC = 1;
    %Fisrt scale the level to 0 and max to one
    time = in_obj.time_sec;
    L = length(in_obj.amp_db(:,1));
    amp = zeros(size(in_obj));
    phs = zeros(size(in_obj));
    for freq_ind=1:1:length(in_obj.freqs)       
       amp(1:L,freq_ind) = in_obj.amp_db(:,freq_ind)-in_obj.amp_db(1,freq_ind);
       phs(1:L,freq_ind) = in_obj.phase_deg(:,freq_ind)-in_obj.phase_deg(1,freq_ind);
    end
    avg_amp = mean(amp,2);
    avg_phs = mean(phs,2);
    smooth_amp = smooth(avg_amp,70); %Smooth about 5 seconds (Assume 60ms delay)
    smooth_phs = smooth(avg_phs,70);
    flat_amp = avg_amp - smooth_amp;
    flat_phs = avg_phs - smooth_phs;
    
    Fs = length(time)/(time(end)-time(1));

    if plotC
        figure; subplot(3,1,1); plot(time,amp); subplot(3,1,2); plot(time,avg_amp,'b'); 
        hold on; plot(time, smooth_amp,'r');
        subplot(3,1,3); plot(time, flat_amp);
        supTitle('Amplitude');
        figure; subplot(3,1,1); plot(time,phs); subplot(3,1,2); plot(time, avg_phs,'b');
        hold on; plot(time, smooth_phs,'r');
        subplot(3,1,3); plot(time, flat_phs);
        supTitle('Phase');
        
        figure; plot(time,flat_phs,'b');
        
    end
end
