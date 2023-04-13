<script setup>

defineProps({
  rating: Number,
})

</script>

<template>
    <div class="flex">
        <svg v-for="active in rating" :key="active" class="mx-0.5 w-4 h-4 fill-current text-yellow-500" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M10 15l-5.878 3.09 1.123-6.545L.489 6.91l6.572-.955L10 0l2.939 5.955 6.572.955-4.756 4.635 1.123 6.545z"/></svg>
        <svg v-for="inactive in 5-rating" :key="inactive" class="mx-0.5 w-4 h-4 fill-current text-gray-300" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M10 15l-5.878 3.09 1.123-6.545L.489 6.91l6.572-.955L10 0l2.939 5.955 6.572.955-4.756 4.635 1.123 6.545z"/></svg>
    </div>
</template>

